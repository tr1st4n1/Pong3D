using UnityEngine;

public class PaddleControl : MonoBehaviour {
    
    public Rigidbody rb;
    public Transform tr;

    void Update()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        // Screen Range
        float minScreenY = Screen.height/4;
        float maxScreenY = Screen.height-minScreenY;

        // Paddle Movement Range
        float paddleMinPos = GetComponent<PaddleData>().paddleMinPos;
        float paddleMaxPos = GetComponent<PaddleData>().paddleMaxPos;

        float mouseY = Input.mousePosition.y;

        // Clamp mouse y to screen range
        mouseY = Mathf.Clamp(mouseY, minScreenY, maxScreenY);

        // Convert mouse y position to a value 0-1
        float normalizedMouseY = Mathf.InverseLerp(minScreenY, maxScreenY, mouseY);

        // Convert the above value to a value between min and max
        float clampedMouseY = Mathf.Lerp(paddleMinPos, paddleMaxPos, normalizedMouseY);

        // Move the paddle to the new position
        tr.position = new (tr.position.x, tr.position.y, clampedMouseY);

    }

}
