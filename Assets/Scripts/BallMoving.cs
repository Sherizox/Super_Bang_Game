using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
   
    public float Size;
    private Rigidbody2D BallRigidbody;
    public float BallDirection;
    bool StartCollision;
  
    void Start()
    {
        
        BallRigidbody = GetComponent<Rigidbody2D>();
        BallRigidbody.AddForce(new Vector2(Random.Range(3f,6f)*BallDirection, 0),ForceMode2D.Impulse);
        transform.localScale = new Vector2(Size, Size);
        StartCollision = false;
        
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!StartCollision)
        {
            if (Size >= 2.0f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.05f;
            }
            else if (Size >= 1.0f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.2f;
            }
            else if (Size >= 0.5f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.4f;
            }
            else
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.4f;
            }

            StartCollision = true;

        }
        else
        {
           if (Size >= 2.0f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.015f;
            }
            else if (Size >= 1.0f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.03f;
            }
            else if (Size >= 0.5f)
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.05f;
            }
            else
            {
                BallRigidbody.GetComponent<Rigidbody2D>().drag = 0.07f;
            }
        }
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
        if (collision.gameObject.tag == "Boundry")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        }
        if (collision.gameObject.tag == "Boundry")
        {
            gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
