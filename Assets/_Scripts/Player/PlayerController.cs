using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	

	void Start ()
	{
		
	}


	void Update ()
	{
	
	}

	public void SnapToPoint (Vector3 point)
	{
		if (point == transform.position)
			return;

		transform.position = point;
	}
}
