using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;
    [SerializeField] private bool isLocked;
    [SerializeField] private int keyCount = 0;
    [SerializeField] private int keysNeeded;

    [ContextMenu("Interact")]
    public void Open()
    {
        if (keyCount >= keysNeeded) isLocked = false;
        if (!isLocked) onOpen.Invoke();
    }
    public void Close()
    {
        onClose.Invoke();
    }

    public void GetKey()
    {
        keyCount++;
    }
}
