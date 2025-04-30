using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuCanvas;

    public void StartGame()
    {
        startMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}