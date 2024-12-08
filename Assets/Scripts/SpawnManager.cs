using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnBall;
    public float spawnPosX , spawnPosY ;
    float StartTime = 2, Repeat = 8;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Respawn", StartTime, Repeat);
    }

    void Respawn()
    {
        spawnPosX = Random.Range(-8f, 8f);
        spawnPosY = Random.Range(2f, 4f);

        SpawnBall.gameObject.GetComponent<BallMoving>().Size = Random.Range(2f, 2.5f);
       
        if (spawnPosX < 0)
        {
            SpawnBall.gameObject.GetComponent<BallMoving>().BallDirection = 1f;
        }
        else
        { SpawnBall.gameObject.GetComponent<BallMoving>().BallDirection = -1f; }
      
        Instantiate(SpawnBall, new Vector3(spawnPosX, spawnPosY, 0), SpawnBall.transform.rotation);
        
    }
}
