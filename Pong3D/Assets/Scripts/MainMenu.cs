using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void SettingsButtonClicked()
    {

    }

    public void QuitButtonClicked()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
