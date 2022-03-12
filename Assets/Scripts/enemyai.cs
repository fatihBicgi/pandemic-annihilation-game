using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyai : MonoBehaviour
{
    public float hiz;
    Vector3 poz;
    public Transform Target;
    public GameObject Die, butt;
    public int health = 20;
    bool isPaused = false;
    private bool blueT;
    private bool redT;
 


    void Awake()
    {
        
        Target = GameObject.Find("char").transform;
        butt = GameObject.Find("RetButton");
        

        if (gameObject.tag == "blueTeam")
        {
            blueT = true;
        }
        if (gameObject.tag == "redTeam")
        {
            redT = true;
        }


    }
    void FixedUpdate()
    {
        poz = new Vector3(Target.position.x, transform.position.y, Target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Target.position, hiz * Time.fixedDeltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TargetPoint")
        {
            butt.GetComponent<Image>().enabled = true;
            butt.GetComponentInChildren<Text>().enabled = true;
            pauseGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="redMask" && redT)
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "blueMask" && blueT)
        {
            
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            print("gg easy");
        }

    }
    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            

        }
    }
}
