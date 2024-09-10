using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Rigidbody rb;

    Vector3 speeds = new (1,0,1);

    void Start()
    {
        float xDirection = Random.Range(0,2)==0 ? -1:1;
        float zDirection = Random.Range(0,2)==0 ? -1:1;

        float xSpeed = speeds.x*xDirection;
        float zSpeed = speeds.z*zDirection;
        Debug.Log($"X: {xSpeed}, Z: {zSpeed}");

        Vector3 impulse = new (xSpeed, 0, zSpeed);

        rb.AddForce(impulse, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag=="GameEndBorder")
        {
            FindObjectOfType<GameManager>().RestartGame(false);
        }
        if (collisionInfo.collider.tag=="RightPaddle")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
