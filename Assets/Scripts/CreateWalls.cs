using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWalls : MonoBehaviour
{

	bool creating;
	public GameObject start;
	public GameObject end;

	public GameObject wallPrefab;
	GameObject wall;

	bool xSnapping;
	bool zSnapping;

	// Use this for initialization
	void Start()
	{

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
			setStart();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			setEnd();
		}
		else
		{
			if (creating)
			{
				adjust();
			}
		}

		if (Input.GetKey(KeyCode.X))
		{
			zSnapping = true;
		}
		else
		{
			zSnapping = false;
		}

		if (Input.GetKey(KeyCode.Y))
		{
			xSnapping = true;
		}
		else
		{
			xSnapping = false;
		}
	}

	Vector3 gridSnap(Vector3 originalPosition)
	{
		int granularity = 1;
		Vector3 snappedPosition = new Vector3(Mathf.Floor(originalPosition.x / granularity) * granularity, originalPosition.y, Mathf.Floor(originalPosition.z / granularity) * granularity);
		return snappedPosition;
	}


	void setStart()
	{
		creating = true;
		start.transform.position = gridSnap(getWorldPoint());
		wall = (GameObject)Instantiate(wallPrefab, start.transform.position, Quaternion.identity);
	}

	void setEnd()
	{
		creating = false;
		end.transform.position = gridSnap(getWorldPoint());
	}

	void adjust()
	{
		end.transform.position = gridSnap(getWorldPoint());
		if (xSnapping)
		{
			end.transform.position = new Vector3(start.transform.position.x, end.transform.position.y, end.transform.position.z);
		}
		if (zSnapping)
		{
			end.transform.position = new Vector3(end.transform.position.x, end.transform.position.y, start.transform.position.z);
		}
		adjustWall();

	}

	void adjustWall()
	{
		start.transform.LookAt(end.transform.position);
		end.transform.LookAt(start.transform.position);
		float distance = Vector3.Distance(start.transform.position, end.transform.position);
		wall.transform.position = start.transform.position + distance / 2 * start.transform.forward;
		wall.transform.rotation = start.transform.rotation;
		wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distance);
	}

	Vector3 getWorldPoint()
	{
		Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			return hit.point;
		}
		return Vector3.zero;
	}
}