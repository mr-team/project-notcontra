using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	static PlayerController playerController;

	void Start ()
	{
		if (playerController == null)
			playerController = GetComponent<PlayerController> ();
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
