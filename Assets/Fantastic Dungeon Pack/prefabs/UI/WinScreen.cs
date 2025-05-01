using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreenCanvas;

    public void ShowWinScreen()
    {
        winScreenCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}