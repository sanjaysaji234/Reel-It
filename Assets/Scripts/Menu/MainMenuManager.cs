using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu,MenuButtons,inGameButtons,pauseMenu;
    SceneLoader loader;
    private void Start()
    {
        loader = FindAnyObjectByType<SceneLoader>();
        if (MenuButtons != null)
        {
            MenuButtons.SetActive(true);
        }
        if (settingsMenu != null)
        {

            settingsMenu.SetActive(false);
        }
    }
    public void OnSettingsClick()
    {
        if (MenuButtons!=null)
        {

            MenuButtons.SetActive(false);
        }
        if (inGameButtons != null)
        {
            inGameButtons.SetActive(false);
        }
        settingsMenu.SetActive(true);
    }
    public void OnSettingsCloseClick()
    {
        if (MenuButtons != null)
        {

            MenuButtons.SetActive(true);
        }

        if (inGameButtons != null)
        {
            inGameButtons.SetActive(true);
        }
        settingsMenu.SetActive(false);
    }
    
    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnPauseClick()
    {
        inGameButtons.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }

    public void OnResumeClick()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        inGameButtons.SetActive(true);
    }

    public void OnPlayClick()
    {
        if (pauseMenu != null)
        {

            pauseMenu.SetActive(false);
        }
        if (MenuButtons != null)
        {
            MenuButtons.SetActive(false);
        }
    }
}
