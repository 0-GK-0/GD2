using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    private Transform _camTransform;
    private IInteractable _currentInteractable;

    [Header("Interaction Settings")]
    [SerializeField] private float interactionDistance = 3f;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private InputActionReference interactAction;

    private void Awake()
    {
        _camTransform = Camera.main.transform;
    }

    private void Update()
    {
        DetectInteractable();
    }
    private void OnEnable()
    {
        interactAction.action.performed += HandleInteraction;
    }
    private void OnDisable()
    {
        interactAction.action.performed -= HandleInteraction;
    }
    private void HandleInteraction(InputAction.CallbackContext context)
    {
        if(_currentInteractable != null)
        {
            _currentInteractable.Interact();
        }
    }
    private void DetectInteractable()
    {
        var ray = new Ray(_camTransform.position, _camTransform.forward);
        IInteractable detectedInteractable = null;
        if (Physics.Raycast(ray, out var hit, interactionDistance, interactionLayer))
        {
            hit.collider.TryGetComponent(out detectedInteractable);
        }
        if(_currentInteractable != detectedInteractable)
        {
            _currentInteractable = detectedInteractable;
        }
    }
}
