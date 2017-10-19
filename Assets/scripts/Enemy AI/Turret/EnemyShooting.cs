using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Lucas
public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefrab;

	public Vector3 bulletOffset = new Vector3 (0, 0.5f, 0); 

	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0) {
			//Shoot!
			Debug.Log ("PEW!");
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset; 

			GameObject bulletGo = (GameObject)Instantiate (bulletPrefrab, transform.position + offset, transform.rotation); 
			bulletGo.layer = gameObject.layer; 
		}
	}
}

