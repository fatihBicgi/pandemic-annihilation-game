using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForBuild : MonoBehaviour
{
    ShowMousePosition pointer;
    bool side=false;
    public GameObject redMask,blueMask;
    private bool setIt=true;
    Vector3 dontRepeat;
    public  float wearSpeed;
    public float  maskTime=0;
    private bool maskUse = false;

    // Start is called before the first frame update
    void Start()
    {
        pointer = GetComponent<ShowMousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current = pointer.getWorldPoint();
        current = pointer.snapPosition(current);
        if (Input.GetKeyDown(KeyCode.E))
        {
            side = !side;
        }

        if (Input.GetMouseButtonDown(0) && !maskUse)
        {
            maskUse = true;

            if (side)
            {            
                    GameObject newpole = Instantiate(redMask, current, Quaternion.Euler(90, 90, 0));
            }
            else
            {               
                    GameObject newpole = Instantiate(redMask, current, Quaternion.Euler(90, 0, 0)); 
            }            
        }

        if (Input.GetMouseButtonDown(1) &&!maskUse)
        {
            maskUse = true;
            if (side)
            { 
                    GameObject newpole = Instantiate(blueMask, current, Quaternion.Euler(90, 90, 0));
            }
            else
            {           
                    GameObject newpole = Instantiate(blueMask, current, Quaternion.Euler(90, 0, 0));
            }
        }
        if (maskUse)
        {
            if (maskTime > wearSpeed)
            {
                maskTime = 0;
                maskUse = false;
            }
            else
            {
                maskTime += Time.deltaTime;
            }
        }
    }
}
