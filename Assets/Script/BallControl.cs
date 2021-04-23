using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Vector2 trajectoryOrigin;

    private Rigidbody2D rb;

    public float xInitialForce;
    public float yInitialForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;

        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetBall()
    {
        transform.position = Vector2.zero;

        rb.velocity = Vector2.zero;
    }

    void PushBall()
    {
        yInitialForce = yInitialForce * ((Random.Range(0, 1) * 2) - 1);
        float randomDirection = Random.Range(0, 2);
         
        if (randomDirection < 1.0f)
        {
            rb.AddForce(new Vector2(-xInitialForce, yInitialForce));
        }
        else
        {
            rb.AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
