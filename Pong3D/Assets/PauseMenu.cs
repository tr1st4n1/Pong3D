using UnityEngine;

public class PauseMenu : MonoBehaviour {
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuPanel;
    public GameObject gameCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        gameCanvas.SetActive(true);
        GameIsPaused = false;
    }

    public void Pause()
    {
        gameCanvas.SetActive(false);
        pauseMenuPanel.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
}
