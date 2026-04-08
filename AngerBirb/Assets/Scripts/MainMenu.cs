using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public void Settings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void back()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Return()
    {
        Debug.Log("DOne");
        SceneManager.LoadScene("StartMenu");
    }
}
