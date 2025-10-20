using UnityEngine;
using UnityEngine.Events;

public class Interacting : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;

    [ContextMenu("Interact")]
    public void Interact()
    {
        onInteract.Invoke();
    }
}
