using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused=false;
    public GameObject pauseMenuUI;
    public GameObject Menu;
    public GameObject Setting;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GamePaused=false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GamePaused=true;
    }
    public void LoadMenu()
    {
        Menu.SetActive(false);
        Setting.SetActive(true);
    }
    public void ReturnPause()
    {
        Menu.SetActive(true);
        Setting.SetActive(false);
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("quit");
        Application.Quit();
    }
}
