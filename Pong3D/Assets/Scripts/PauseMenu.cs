using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuPanel;
    public GameObject gameCanvas;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                audioManager.PlaySFX(audioManager.button);
                Resume();
            }
            else if (!GameIsPaused)
            {
                audioManager.PlaySFX(audioManager.button);
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

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
