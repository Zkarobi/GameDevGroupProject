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
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        uiManager.ShowPauseMenu();  // Show pause menu via UIManager
        isPaused = true;
    }

    public void ResumeGame()
    {
        uiManager.ResumeGame();     // Resume via UIManager
        isPaused = false;
    }

    public void ExitToMenu()
    {
        uiManager.ReturnToStartMenu();
        isPaused = false;
    }
}
