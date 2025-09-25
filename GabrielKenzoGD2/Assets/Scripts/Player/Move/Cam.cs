using UnityEngine;

public class Cam : MonoBehaviour
{
    public float sensitivity;
    public Transform cam;
    public float mouseX;
    public float mouseY;
    public float rotX;
    public float rotY;
    public bool isY;
    public bool isX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        if(isX) rotX -= mouseY;
        if(isY) rotY -= mouseX;

        cam.localRotation = Quaternion.Euler(rotX, -rotY, 0);

        rotX = Mathf.Clamp(rotX, -90f, 90f);
    }
}
