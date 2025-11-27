using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Lock : MonoBehaviour
{
    [SerializeField] private UnityEvent onOpen;
    [SerializeField] private UnityEvent onClose;
    [SerializeField] private bool isLocked;
    [SerializeField] private int keysNeeded;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    [SerializeField] private KeysCol keysCol;

    [ContextMenu("Interact")]
    public void Open()
    {
        if (keysCol.keyCount >= keysNeeded) isLocked = false;
        if (!isLocked) onOpen.Invoke();
        else
        {
            StartCoroutine(PlaySound());
        }
    }
    public void Close()
    {
        onClose.Invoke();
    }

    private IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        audioSource.Stop();
    }
}
