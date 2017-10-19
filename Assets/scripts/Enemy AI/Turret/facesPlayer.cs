using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Lucas
public class facesPlayer : MonoBehaviour {

	public float rotSpeed = 180f;

	Transform player;
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
		 	//find the players ship!
			GameObject go = GameObject.FindWithTag("Player");
			if (go != null) {
				player = go.transform;
			}
		}
		//at this poit we have found a player or the player dose not exist right now 
		if (player == null)
			return; // try again next frame!

		//Here whe know for sure we have a player. Turn to face it!

		Vector3 dir = player.position - transform.position; 
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot  = Quaternion.Euler (0, 0, zAngle); 

		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}
