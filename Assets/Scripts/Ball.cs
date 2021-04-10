using UnityEngine;

public class Ball : MonoBehaviour
{
    Paddle paddle;
    Vector3 paddleToBallVector;
    bool hasStarted = false;

    private void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    private void Update()
    {
        if (!hasStarted)
        {
            //Lock the ball relative to the paddle
            transform.position = paddle.transform.position + paddleToBallVector;

            //Wait for a mouse press to launch.
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse Clicked, launch ball.");
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2, 10);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.3f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
