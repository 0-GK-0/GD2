using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
