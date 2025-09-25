using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneToChange;
    public bool canGo;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && canGo)
            SceneManager.LoadScene(sceneToChange);
    }
}
