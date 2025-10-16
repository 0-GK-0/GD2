using Unity.Collections;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public GameObject player;
    public float wanderSpeed;
    public float runSpeed;
    public float speed;
    public float rotSpeed;
    public float detectionRange;
    public float minDist = 1.5f;
    public Transform playerPos;
    public Rigidbody rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.GetComponent<Transform>();
    }
    private void Update()
    {
        if (playerPos == null)
        {
            speed = wanderSpeed;
        }
        else
        {
            Vector3 direction = playerPos.position - transform.position;
            float distance = direction.magnitude;
            Quaternion rot = Quaternion.LookRotation(direction).normalized;
            speed = runSpeed;
            if (distance < detectionRange)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotSpeed);
                if (distance > minDist) transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, detectionRange);
    }
}
