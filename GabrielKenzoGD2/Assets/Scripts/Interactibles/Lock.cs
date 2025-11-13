using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;
    [SerializeField] private bool isLocked;
    [SerializeField] private int keysNeeded;

    [SerializeField] private KeysCol keysCol;

    [ContextMenu("Interact")]
    public void Open()
    {
        if (keysCol.keyCount >= keysNeeded) isLocked = false;
        if (!isLocked) onOpen.Invoke();
    }
    public void Close()
    {
        onClose.Invoke();
    }
}
