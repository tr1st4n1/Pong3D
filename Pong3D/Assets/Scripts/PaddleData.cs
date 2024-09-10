using UnityEngine;

public class PaddleData : MonoBehaviour {

    public float paddleLength;
    public float frameHeight;
    public float paddleMinPos;
    public float paddleMaxPos;

    void Start()
    {
        paddleMinPos = (-frameHeight/2)+(paddleLength/2);
        paddleMaxPos = (frameHeight/2)-(paddleLength/2);
    }

}
    
