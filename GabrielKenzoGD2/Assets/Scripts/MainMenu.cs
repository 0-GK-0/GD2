using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject canvas;

    private void Start(){
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) Return();
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Controls()
    {
        canvas.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
    }
    public void Credits()
    {
        canvas.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(true);
    }
    public void Return()
    {
        controls.SetActive(false);
        credits.SetActive(false);
        canvas.SetActive(true);
    }
}
