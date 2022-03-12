using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    public float time, totaltime;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>=totaltime)
        {
            Destroy(gameObject);
        }
    }
}
