using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ToggableInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isOpen;
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;

    public void Interact()
    {
        if (isOpen)
        {
            onClose.Invoke();
        }
        else
        {
            onOpen.Invoke();
        }
        isOpen = !isOpen;
    }
}
