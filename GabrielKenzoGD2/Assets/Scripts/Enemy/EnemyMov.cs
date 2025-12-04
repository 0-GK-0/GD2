using Unity.Collections;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public GameObject player;
    public float wanderSpeed;
    public float runSpeed;
    public float speed;
    public float rotSpeed;
    public float minDist = 1.5f;
    public Transform playerPos;

    [SerializeField] private GameObject jumpscare;
    [SerializeField] private Move move;
    [SerializeField] private GameObject cam;
    [SerializeField] private Material ghostMat;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.GetComponent<Transform>();
    }
    private void Update()
    {
        Vector3 direction = playerPos.position - transform.position;
        float distance = direction.magnitude;
        Quaternion rot = Quaternion.LookRotation(direction).normalized;
        speed = runSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed);
        if (distance > minDist) transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            jumpscare.SetActive(true);
            move.walkSpeed = 0;
            move.sprintSpeed = 0;
            move.crouchSpeed = 0;
            cam.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Renderer renderer = other.GetComponent<Renderer>();
            if(renderer != null)
            {
                renderer.material = ghostMat;
            }
        }
    }
}
