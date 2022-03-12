using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fenceCreator : MonoBehaviour
{
	ShowMousePosition pointer;
	bool creating;
	public GameObject fence;
	public GameObject pole;
	GameObject lastpole;


	// Start is called before the first frame update
	void Start()
    {
		pointer=GetComponent<ShowMousePosition>();
    }

    // Update is called once per frame
    void Update()
    {
		getInput();
    }
	void getInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			startFence();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			setFence();
		}
		else
		{
			if (creating)
			{
				updateFence();
			}
		}
	}
	void startFence()
	{
		creating = true;
		Vector3 startpos = pointer.getWorldPoint();
		startpos = pointer.snapPosition(startpos);
		GameObject startpole =Instantiate(pole, startpos, Quaternion.identity);
		startpole.transform.position = new Vector3(startpos.x, startpos.y + 0.3f, startpos.z);
		lastpole = startpole;
	}

	void setFence()
	{
		creating = false;

	}
	void updateFence()
	{
		Vector3 current = pointer.getWorldPoint();
		current = pointer.snapPosition(current);
		current = new Vector3(current.x, current.y + 0.3f, current.z);
		if (!current.Equals(lastpole.transform.position))
		{
			createFence(current);
		}
	}
	void createFence(Vector3 current)
	{
		GameObject newpole = Instantiate(pole, current, Quaternion.identity);
		Vector3 middle = Vector3.Lerp(newpole.transform.position, lastpole.transform.position, 0.5f);
		GameObject newfence = Instantiate(fence, middle, Quaternion.identity);
		newfence.transform.LookAt(lastpole.transform);
		lastpole = newpole;
	}
}
