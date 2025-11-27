using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private UnityEvent onDetect;

    [ContextMenu("Interact")]

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onDetect.Invoke();
        }
    }
}
