using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour {

    float ballSpeed;
    int highscore;

    void Start()
    {
        Load();
    }

    public void SetBallSpeed(float _ballSpeed)
    {
        ballSpeed = _ballSpeed;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("BallSpeed", ballSpeed);
    }

    public void Load()
    {
        ballSpeed = PlayerPrefs.GetFloat("BallSpeed");
        FindObjectOfType<Slider>().value = ballSpeed;

        highscore = PlayerPrefs.GetInt("Highscore");
    }
}
