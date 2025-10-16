using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class Move : MonoBehaviour
{
    [Header("Speed")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2f;

    [Header("Jump and Fall")]
    public float jumpForce = 7f;
    public float gravity = -12f;
    [SerializeField] private float initialFallVelocity = -2f;

    [Header("Crouching")]
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float crouchingHeight = 1f;
    [SerializeField] private float crouchTransitionSpeed = 10f;
    [SerializeField] private float camOffset = 0.4f;

    [Header("CamShake")]
    [SerializeField] private float amplitudeTransitionSpeed = 1f;
    [SerializeField] private float bobbingAmplitudeIdle;
    [SerializeField] private float bobbingAmplitudeMoving;
    [SerializeField] private float bobbingIdle;
    [SerializeField] private float bobbingWalk;
    [SerializeField] private float bobbingSprint;
    [SerializeField] private float bobbingCrouch;

    [Header("References")]
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private Transform camTransform;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private InputActionReference crouchAction;
    [SerializeField] private InputActionReference sprintAction;

    private CharacterController _characterController;
    private Vector2 _moveInput;
    private bool _isGrounded;
    private bool _isRunning;
    private bool _isCrouching;
    private float _verticalVelocity;
    private float _targetHeight;
    private float _targetAmplitude;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _targetHeight = standingHeight;
    }


    private void OnEnable()
    {
        moveAction.action.performed += StoreMovementInput;
        moveAction.action.canceled += StoreMovementInput;
        jumpAction.action.performed += Jump;
        sprintAction.action.performed += Sprint;
        sprintAction.action.canceled += Sprint;
        crouchAction.action.performed += Crouch;
    }
    private void OnDisable()
    {
        moveAction.action.performed -= StoreMovementInput;
        moveAction.action.canceled -= StoreMovementInput;
        jumpAction.action.performed -= Jump;
        sprintAction.action.performed -= Sprint;
        sprintAction.action.canceled -= Sprint;
        crouchAction.action.performed -= Crouch;
    }

    private void Sprint(InputAction.CallbackContext context)
    {
        _isRunning = context.performed;
    }
    private void Crouch(InputAction.CallbackContext context)
    {
        if (_isCrouching)
        {
            if (!CanStandUp())
            {
                return;
            }
            _targetHeight = standingHeight;
        }
        else
        {
            _targetHeight = crouchingHeight;
        }
        _isCrouching = !_isCrouching;
    }
    private bool CanStandUp()
    {
        return !Physics.CapsuleCast(
            transform.position + _characterController.center,
            transform.position + (Vector3.up * _characterController.height / 2),
            _characterController.radius,
            Vector3.up
        );
    }

    private void Update()
    {
        _isGrounded = _characterController.isGrounded;
        HandleGravity();
        HandleMovement();
        HandleCrouchTransition();
    }


    private void StoreMovementInput(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }
    
    private void Jump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _verticalVelocity = jumpForce;
        }
    }

    private void HandleGravity()
    {
        if (_isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = initialFallVelocity;
        }
        _verticalVelocity += gravity * Time.deltaTime;
    }
    private void HandleMovement()
    {
        var move = camTransform.TransformDirection(new Vector3(_moveInput.x, 0, _moveInput.y)).normalized;
        var currentSpeed = _isCrouching ? crouchSpeed : _isRunning ? sprintSpeed : walkSpeed;
        var finalMove = move * currentSpeed;
        finalMove.y = _verticalVelocity;

        var perlin = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        var currentAmplitude = perlin.AmplitudeGain;
        if (finalMove.x != 0 && finalMove.y != 0)
        {
            if (_isCrouching)
                perlin.FrequencyGain = bobbingCrouch;
            else if (_isRunning)
                perlin.FrequencyGain = bobbingSprint;
            else
                perlin.FrequencyGain = bobbingWalk;
            _targetAmplitude = bobbingAmplitudeMoving;
            if (Mathf.Abs(currentAmplitude - _targetAmplitude) > 0.01f)
            {
                perlin.AmplitudeGain = Mathf.Lerp(currentAmplitude, _targetAmplitude, amplitudeTransitionSpeed);
            }
        }
        else
        {
            perlin.FrequencyGain = bobbingIdle;
            _targetAmplitude = bobbingAmplitudeIdle;
            if (Mathf.Abs(currentAmplitude - _targetAmplitude) > 0.01f)
            {
                perlin.AmplitudeGain = Mathf.Lerp(currentAmplitude, _targetAmplitude, amplitudeTransitionSpeed);
            }
        }

        var collisions = _characterController.Move(finalMove * Time.deltaTime);
        if ((collisions & CollisionFlags.Above) != 0)
        {
            _verticalVelocity = initialFallVelocity;
        }
    }
    
    private void HandleCrouchTransition()
    {
        var currentHeight = _characterController.height;
        if (Mathf.Abs(currentHeight - _targetHeight) < 0.01f)
        {
            _characterController.height = _targetHeight;
            return;
        }

        var newHeight = Mathf.Lerp(currentHeight, _targetHeight, crouchTransitionSpeed * Time.deltaTime);
        _characterController.height = newHeight;
        _characterController.center = Vector3.up * (newHeight * 0.5f);

        var camTargetPos = camTransform.localPosition;
        camTargetPos.y = _targetHeight - camOffset;
        camTransform.localPosition = Vector3.Lerp(
            camTransform.localPosition,
            camTargetPos,
            crouchTransitionSpeed * Time.deltaTime);
    }
}
