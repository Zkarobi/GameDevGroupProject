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
        var audio = FindObjectOfType<AudioManager>();

        if (hasStartedGame)
        {
            startMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

            if (audio != null)
            {
                audio.PlayMusic(audio.gameMusic);
                audio.PlayAmbience(audio.ambienceLoop);
            }
        }
        else
        {
            startMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

            if (audio != null)
            {
                audio.PlayMusic(audio.mainMenuMusic);
            }
        }
    }

    private bool isPaused = false;

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>()?.PlaySFX(FindObjectOfType<AudioManager>().clickSound);

        hasStartedGame = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        var audio = FindObjectOfType<AudioManager>();
        if (audio != null)
        {
            audio.uiSource.Stop();
            audio.PlaySFX(audio.clickSound);
            audio.ResumeMusic();
            audio.PlayAmbience(audio.ambienceLoop);
        }

        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }



    public void ShowPauseMenu()
    {
        var audio = FindObjectOfType<AudioManager>();
        if (audio != null)
        {
            audio.PlaySFX(audio.clickSound);
            audio.PlayUISFX(audio.pauseSound);
            audio.PauseMusic();
            audio.StopAmbience();
        }

        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ShowWinScreen()
    {
        FindObjectOfType<AudioManager>()?.PlaySFX(FindObjectOfType<AudioManager>().winSound);

        winScreenCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReplayGame()
    {
        FindObjectOfType<AudioManager>()?.PlaySFX(FindObjectOfType<AudioManager>().clickSound);

        ReturnToStartMenu();
    }

    public void ReturnToStartMenu()
    {
        var audio = FindObjectOfType<AudioManager>();
        if (audio != null)
        {
            audio.uiSource.Stop();
            audio.PlaySFX(audio.clickSound);
            audio.StopMusic();
            audio.StopAmbience();
            audio.PlayMusic(audio.mainMenuMusic);
        }

        pauseMenuCanvas.SetActive(false);
        winScreenCanvas.SetActive(false);
        startMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = false;
    }


    public void QuitGame()
    {
        FindObjectOfType<AudioManager>()?.PlaySFX(FindObjectOfType<AudioManager>().clickSound);

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
