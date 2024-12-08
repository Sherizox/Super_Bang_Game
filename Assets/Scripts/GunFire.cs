using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject[] ballSpawn;
    public float bulletSpeed = 10;


    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * bulletSpeed);
        }
        else
        {
            Destroy(gameObject, 0.1f);
        }

    }
    void Spawning(int _index, Vector3 _position, Quaternion _rotation)
    {
        // left ball
        ballSpawn[_index].gameObject.GetComponent<BallMoving>().BallDirection = -1f;
        Instantiate(ballSpawn[_index], _position, _rotation);
        // right ball
        ballSpawn[_index].gameObject.GetComponent<BallMoving>().BallDirection = 1f;
        Instantiate(ballSpawn[_index], _position, _rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++MenuManager.Score;
        switch (collision.gameObject.name)
        {
            case "MaxBall(Clone)":
                Destroy(collision.gameObject, 0.01f);
                Spawning(0, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                break;

            case "MediumBall(Clone)":
                Destroy(collision.gameObject);
                Spawning(1, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

                break;

            case "SmallBall(Clone)":
                Destroy(collision.gameObject);
                Spawning(2, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

                break;

            case "TinyBall(Clone)":
                Destroy(collision.gameObject);
                break;

            default:
                break;
        }



        Destroy(gameObject, 0.01f);
    }
}