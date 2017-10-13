using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {
    [SerializeField, Range(0.0f, .1f)]
    float health = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (health <= 0)
            Destroy(gameObject);
	}
    //the damage value subtracts from 100
    public void TakeDamage(float damage)
    {
        health = ((health * 100) - damage) / 100;
    }
}
