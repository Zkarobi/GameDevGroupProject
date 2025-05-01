using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public UIManager uiManager;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiManager.IsGamePaused())
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        uiManager.ShowPauseMenu();
    }

    public void ResumeGame()
    {
        isPaused = false;
        uiManager.ResumeGame();
    }


    public void ExitToMenu()
    {
        uiManager.ReturnToStartMenu();
        isPaused = false;
    }
}
