using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Player))]
[RequireComponent (typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
	public bool shouldCameraFollowPlayer = true;
	public bool MoveWithArrows;

	Player player;
	//For the click to move function
	NavMeshAgent navAgent;

	Vector3 targetPosition;

	bool isCrouching;
	bool isProne;
	bool isWalking;
	bool isRunning;

	float moveSpeed;

	void Awake ()
	{
		player = GetComponent<Player> ();
		navAgent = GetComponent<NavMeshAgent> ();
		moveSpeed = player.walkSpeed;
	}

	void Start ()
	{
		targetPosition = transform.position;
	}

	void Update ()
	{
		if (shouldCameraFollowPlayer)
			Camera.main.transform.position = new Vector3 (this.transform.position.x - 15f, 30f, this.transform.position.z - 15f);
		
		//movement
		if (MoveWithArrows) //should the player be controlled by WASD or by clicking on the ground
			WASDMove ();
		else if (!MoveWithArrows)
		{
			ChangeState ();

			if (Input.GetMouseButton (0))
				SetTargetPosition ();

			ClickToMove ();
		}
	}

	void WASDMove ()
	{
		float moveX = Input.GetAxis ("Horizontal");
		float movez = Input.GetAxis ("Vertical");
		float Speed = player.walkSpeed;
		float crouchSpeed = player.walkSpeed * 0.6f;

		Vector3 dir = new Vector3 (moveX, 0, movez);

		if (Input.GetKey (KeyCode.LeftShift))
		{
			Speed = crouchSpeed;
		}
		transform.localPosition += dir * Speed * Time.deltaTime;
	}

	void ClickToMove ()
	{
		if (isRunning)
		{
			moveSpeed = player.runSpeed;
		}
		if (isWalking)
		{
			moveSpeed = player.walkSpeed;
		}
		if (isCrouching)
		{
			moveSpeed = player.crouchSpeed;
		}
		if (isProne)
		{
			moveSpeed = player.proneSpeed;
		}
		 
		navAgent.speed = moveSpeed;
		navAgent.SetDestination (targetPosition);
	}

	void SetTargetPosition ()
	{
		Plane plane = new Plane (Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float point = 0f;

		if (plane.Raycast (ray, out point))
			targetPosition = ray.GetPoint (point);	
	}

	/// <summary>
	/// /Changes the movement state of the player*/
	/// </summary>
	void ChangeState ()
	{
		if (Input.GetButtonDown ("Crouch"))
		{
			isCrouching = true;

			isProne = false;
			isWalking = false;
			isRunning = false;
		}

		if (Input.GetButtonDown ("Prone"))
		{
			isProne = true;

			isCrouching = false;
			isWalking = false;
			isRunning = false;
		}

		if (Input.GetButtonDown ("Walk"))
		{
			isWalking = true;

			isProne = false;
			isCrouching = false;
			isRunning = false;
		}

		if (Input.GetButtonDown ("Run"))
		{
			isRunning = true;

			isProne = false;
			isCrouching = false;
			isWalking = false;
		}	
	}

	void HandleAnimation ()
	{
		
	}

	public void SnapToPoint (Vector3 point)
	{
		if (point == transform.position)
			return;

		transform.position = point;
	}
}
