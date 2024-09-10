using UnityEngine;
using UnityEngine.UI;
#nullable enable

public class GameManager : MonoBehaviour {

    public GameObject? ballPrefab;
    public GameObject? ball;

    public GameObject? explosionPrefab;
    public GameObject? explosion;

    public PhysicMaterial? ballPhysicMat;

    public Text? scoreText;
    public int score;

    void Start()
    {
        score = 0;
        if (scoreText!=null)
        {
            scoreText.text = score.ToString();
        }
        RestartGame(true);
    }

    public void RestartGame(bool _newGame)
    {
        // reset opponent/ai paddle
        float aiX = FindObjectOfType<AIController>().tr.position.x;
        float aiY = FindObjectOfType<AIController>().tr.position.y;
        FindObjectOfType<AIController>().tr.position = new (aiX, aiY, 0);

        // ball exists
        if (ball != null)
        {
            // Explosion
            if (explosion==null && explosionPrefab!=null)
            {
                explosion = Instantiate(explosionPrefab);
                explosion.transform.position = ball.transform.position;
            }

            Destroy(ball);

            // Score
            score = 0;
            if (scoreText!=null)
            {
                scoreText.text = score.ToString();
            }
        }

        // Make sure there is no wait for the explosion to play when there is no explosion
        if (_newGame) {Invoke(nameof(NewBall), 0f);}
        else {Invoke(nameof(NewBall), 1f);}
    }

    void NewBall()
    {
        if (ballPrefab != null)
        {   
            // New Ball
            ball = Instantiate(ballPrefab);
            if (ballPhysicMat!=null) {ballPhysicMat.bounciness = 0;} // disable bounce
            ball.transform.position = new (0,2f,0);

            Destroy(explosion);

            Invoke(nameof(EnableBallMovement), 1.5f);
        }
    }

    void EnableBallMovement()
    {
        if (ball == null) {return;} // because of unity

        if (ballPhysicMat!=null) {ballPhysicMat.bounciness = 1;} // make ball bounce
        ball.transform.position = new (0,0.425f,0); // stop bounce before moving

        ball.GetComponent<BallMovement>().enabled = true;
    }

    public void IncreaseScore()
    {
        score++;
        if (scoreText!=null)
        {
            scoreText.text = score.ToString();
        }

    }
}
