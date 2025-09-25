using Unity.Collections;
using UnityEngine;

public class FPMov : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public float speed;
    float horizontal;
    float vertical;

    public Inventory inventory;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //transform.localRotation = Quaternion.Euler(cam.rotation.x, 0, 0);

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        rb.linearVelocity = direction * speed;
    }
}
