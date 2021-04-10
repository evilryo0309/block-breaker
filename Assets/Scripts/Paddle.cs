using UnityEngine;

public class Paddle : MonoBehaviour
{
    private const float MaxX = 14.83f;
    private const float MinX = 1.171f;

    public bool IsAutoPlay = false;

    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update ()
    {
        if (!IsAutoPlay)
            MoveWithMouse();
        else
            AutoPlay();
    }

    private void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0);

        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, MinX, MaxX);

        transform.position = paddlePos;
    }

    private void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0.5f, transform.position.y, 0);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, MinX, MaxX);

        transform.position = paddlePos;
    }
}
