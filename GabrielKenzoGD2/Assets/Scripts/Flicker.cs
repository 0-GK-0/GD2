using System.Collections;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    private float chosenTime;

    [SerializeField] private GameObject objectToFlicker;

    private void Start()
    {
        chosenTime = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        if (chosenTime > 0) chosenTime -= Time.deltaTime;
        else
        {
            StartCoroutine(FlickerCoroutine());
        }
    }

    private IEnumerator FlickerCoroutine()
    {
        objectToFlicker.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        objectToFlicker.SetActive(true);
        chosenTime = Random.Range(minTime, maxTime);
    }
}
