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
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0.0f, 2.0f);
         
        if (randomDirection < 1.0f)
        {
            rb.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rb.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
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
