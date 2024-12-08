using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10.0f;
    public GameObject ShootBullet;
    float HInput;
    public GameObject OverPanel;
    private Animator Anim;
    bool Hited;
    // Start is called before the first frame update
    void Start()
    {
        Anim=GetComponent<Animator>();
        Anim.SetBool("idle_b", true);
        
    }

    // Update is called once per frames
    void Update()
    {
         PLayerInputs();
         if(Input.GetKeyDown(KeyCode.Space))
         {
            Anim.SetBool("fireState_b", true);
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                Instantiate(ShootBullet, new Vector3(gameObject.transform.position.x - 0.4f, ShootBullet.transform.position.y, 0), ShootBullet.transform.rotation);
            }
            else
            {
                Instantiate(ShootBullet, new Vector3(gameObject.transform.position.x + 0.4f, ShootBullet.transform.position.y, 0), ShootBullet.transform.rotation);
            }
          }
         else
         {
            Anim.SetBool("fireState_b", false); 
          
         }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Hited)
        {
            Hited = false;
            if (MenuManager.Health >= 10)
            {
                MenuManager.Health -= 10;
            }
            else
            {
                print("Game Over");
                OverPanel.SetActive(true);

                Time.timeScale = 0f;
            }
        }
        else
        {
            Hited = true;
        }

    }
    void PLayerInputs()
    {
        HInput = Input.GetAxis("Horizontal");
        if (HInput > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            Anim.SetBool("walk_b", true);
            transform.Translate(Vector3.right * Time.deltaTime * Speed * HInput);
        }
        else if (HInput < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            Anim.SetBool("walk_b", true);
            transform.Translate(Vector3.right * Time.deltaTime * Speed * HInput);
        }
        else
        {
            Anim.SetBool("walk_b", false);
        }


        if (transform.position.x > 7.7f)
        {
            transform.position = new Vector3(7.8f, transform.position.y, 0);
        }
        if (transform.position.x < -7.7f)
        {
            transform.position = new Vector3(-7.8f, transform.position.y, 0);
        }
    }
  
}
