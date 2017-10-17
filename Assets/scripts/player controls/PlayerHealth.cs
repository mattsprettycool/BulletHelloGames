using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    HealthBar hb;
	// Use this for initialization
	void Start () {
        hb = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DamageHealth(float damage)
    {
        hb.DamageHealth(damage);
    }
}
