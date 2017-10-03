using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    [SerializeField]
    GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetAxis("Fire1") != 0) Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
	}
}
