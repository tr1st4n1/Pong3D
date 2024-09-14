using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text highscoreText;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore");
        if (highscore!=0)
        {
            highscoreText.text = $"Highscore: {highscore.ToString()}";
        }
        else if (highscore==0)
        {
            highscoreText.text = $"";
        }
    }

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitButtonClicked()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
