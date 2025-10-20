using System.Collections;
using UnityEngine;

public class DoorInt : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationAmount = 90f;

    private Vector3 startRot;
    private Vector3 forward;

    private Coroutine animCoroutine;

    private void Awake()
    {
        startRot = transform.rotation.eulerAngles;
        forward = transform.right;
    }

    public void Open()
    {
        if (!isOpen)
        {
            if (animCoroutine != null)
            {
                StopCoroutine(animCoroutine);
            }
            animCoroutine = StartCoroutine(DoRotOpen());
            StartCoroutine(PlaySound());

        }
    }

    private IEnumerator DoRotOpen()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;
        
        endRotation = Quaternion.Euler(new Vector3(0, startRot.y + rotationAmount, 0));
        isOpen = true;

        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if (animCoroutine != null)
            {
                StopCoroutine(animCoroutine);
            }
            animCoroutine = StartCoroutine(DoRotClose());
            StartCoroutine(PlaySound());
        }
    }
    private IEnumerator DoRotClose()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRot);

        isOpen = false;
        float time = 0;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * speed;
        }
    }

    private IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        audioSource.Stop();
    }
}
