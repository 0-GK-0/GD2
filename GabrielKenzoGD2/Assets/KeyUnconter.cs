using UnityEngine;
using TMPro;

public class KeyUnconter : MonoBehaviour
{
    [SerializeField] private int keysInRoom;
    private TextMeshPro text;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
    }

    public void Uncount()
    {
        keysInRoom--;
        if(keysInRoom <= 0) Destroy(gameObject);
        text.text = keysInRoom.ToString();
    }
}
