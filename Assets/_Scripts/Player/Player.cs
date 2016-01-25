using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	static Player player;


	void Start ()
	{
		if (player == null)
			player = GetComponent<Player> ();
	
	}


	void Update ()
	{
	
	}
}
