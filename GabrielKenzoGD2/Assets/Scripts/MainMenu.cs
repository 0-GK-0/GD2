using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;

    private void Start(){
        Cursor.lockState = CursorLockMode.None;
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
