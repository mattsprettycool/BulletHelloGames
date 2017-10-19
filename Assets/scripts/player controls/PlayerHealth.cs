using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class PlayerHealth : MonoBehaviour {
    HealthBar hb;
	// Use this for initialization
	void Start () {
        //gets the health bar to mess with it from the player
        hb = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Damages the health from the player
    public void DamageHealth(float damage)
    {
        hb.DamageHealth(damage);
    }
}
