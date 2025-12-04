using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] private float time = 5f;

    private void Update(){
        if(time>0) time -= Time.deltaTime;
        else{
            SceneManager.LoadScene("MainMenu");
        }
    }
}
