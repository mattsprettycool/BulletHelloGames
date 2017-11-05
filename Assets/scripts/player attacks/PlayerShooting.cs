using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    int fireRate;
    int canFire = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //instantiates bullet prefabs on a delay
        if (canFire == 0)
        {
            if (Input.GetAxis("Fire1") != 0)
                Instantiate(bullet, new Vector3(gameObject.transform.position.x-5, gameObject.transform.position.y+30f, gameObject.transform.position.z), gameObject.transform.rotation);
            canFire = fireRate;
        }
        else
            canFire--;
	}
}
