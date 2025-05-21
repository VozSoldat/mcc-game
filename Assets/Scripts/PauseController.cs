using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private GameObject _pauseMenu;

    private void Start()
    {
        _pauseMenu = gameObject;
        _pauseMenu.SetActive(true);
    }

    private void ShowPauseMenu()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }

    public void OnResumeButtonClicked()
    {
        Debug.Log("Resume button clicked");
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
    }

    public void OnRestartClicked()
    {
        Debug.Log("Restart button clicked");
        Time.timeScale = 1f;
        var currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevel.name);
    }

    public void OnQuitClicked()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
