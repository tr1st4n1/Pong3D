using UnityEngine;

public class AIController : MonoBehaviour {
    
    public Transform tr;

    // Legacy Variables
    public const float difficultyRange = 1.5f;
    public const float speed = 13f;

    // Paddle data
    float paddleMinPos;
    float paddleMaxPos;
    
    void Start()
    {
        paddleMinPos = GetComponent<PaddleData>().paddleMinPos;
        paddleMaxPos = GetComponent<PaddleData>().paddleMaxPos;
    }
    
    void Update()
    {
        GameObject ball = FindObjectOfType<GameManager>().ball;
        if (ball!=null)
        {
            MovePaddleEndless(ball.transform);
        }
    }
    
    void MovePaddleEndless(Transform bt)
    {
        float ballZ = bt.position.z;

        // New position
        float x = tr.position.x;
        float y = tr.position.y;
        float z = Mathf.Clamp(ballZ, paddleMinPos, paddleMaxPos);

        tr.position = new (x,y,z);
    }

    // Legacy Functions
    void MovePaddleDifficuly(Transform bt)
    {

        if (tr.position.z > bt.position.z && tr.position.z-difficultyRange >= bt.position.z)
        {
            float x = tr.position.x;
            float y = tr.position.y;
            float z = Mathf.Clamp(tr.position.z - speed * Time.deltaTime, paddleMinPos, paddleMaxPos);
            tr.position = new (x,y,z);
        }
        else if (tr.position.z < bt.position.z && tr.position.z+difficultyRange <= bt.position.z)
        {
            float x = tr.position.x;
            float y = tr.position.y;
            float z = Mathf.Clamp(tr.position.z + speed * Time.deltaTime, paddleMinPos, paddleMaxPos);
            tr.position = new (x,y,z);
        }

    }

}
