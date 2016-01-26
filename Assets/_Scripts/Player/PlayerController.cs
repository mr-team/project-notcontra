using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    public bool shouldCameraFollowPlayer = true;


	void Update () {
        if(shouldCameraFollowPlayer)
            Camera.main.transform.position = new Vector3(this.transform.position.x - 15f, 30f, this.transform.position.z - 15f);
	}

	public void SnapToPoint (Vector3 point)
	{
		if (point == transform.position)
			return;

		transform.position = point;
	}
}
