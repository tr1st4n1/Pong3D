using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    void Start()
    {
        Load();
    }

    public void Save(float ballSpeed)
    {
        PlayerPrefs.SetFloat("BallSpeed", ballSpeed);
    }

    public void Load()
    {
        FindObjectOfType<Slider>().value = PlayerPrefs.GetFloat("BallSpeed");
    }
}
