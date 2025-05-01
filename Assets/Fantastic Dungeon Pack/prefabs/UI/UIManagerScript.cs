using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public GameObject startMenuCanvas;
    public GameObject pauseMenuCanvas;
    public GameObject winScreenCanvas;

    private static bool hasStartedGame = false;

    void Start()
    {
        if (hasStartedGame)
        {
            startMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            startMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartGame()
    {
        hasStartedGame = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowPauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWinScreen()
    {
        winScreenCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReplayGame()
    {
        ReturnToStartMenu();
    }

    public void ReturnToStartMenu()
    {
        pauseMenuCanvas.SetActive(false);
        winScreenCanvas.SetActive(false);
        startMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
