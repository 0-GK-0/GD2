using UnityEngine;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro keyText;
    [SerializeField] private int keysNeeded;
    [SerializeField] private KeysCol keysCol;

    private void Update()
    {
        keyText.text = (keysNeeded - keysCol.keyCount).ToString();
        if((keysNeeded - keysCol.keyCount) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
