using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus : MonoBehaviour
{
    public GameObject Boss1, Boss2;
    public float idealTime;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > idealTime)
        {
            time = 0;
            int randomNumber = Random.Range(1, 3);

            if (randomNumber == 1)
            {
                GameObject effect = Instantiate(Boss1, transform.position, Quaternion.identity);
            }
            else
            {
                GameObject effect = Instantiate(Boss2, transform.position, Quaternion.identity);
            }
        }
        time = time + Time.deltaTime;


    }
}
