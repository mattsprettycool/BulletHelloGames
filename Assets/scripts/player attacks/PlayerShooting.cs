using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float fireRate;
    float canFire = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //instantiates bullet prefabs on a delay
        if (canFire <= 0)
        {
            if (Input.GetAxis("Fire1") != 0 && !(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y + 30f, gameObject.transform.position.z), gameObject.transform.rotation);
                canFire = fireRate;
            }
            else if (Input.GetAxis("Fire1") != 0 && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                Instantiate(bullet, new Vector3(gameObject.transform.position.x - 5, gameObject.transform.position.y + 30f, gameObject.transform.position.z), gameObject.transform.rotation);
                canFire = fireRate / 2;
            }
        }
        else
            canFire-=Time.deltaTime;
	}
}
