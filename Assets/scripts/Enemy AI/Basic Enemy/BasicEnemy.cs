using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class BasicEnemy : MonoBehaviour {
    //stores the health as a decimal value; .1 = 100%
    [SerializeField, Range(0.0f, 100f)]
    float health = .1f;
    //This is the damage that the enemy deals on collision
    [SerializeField]
    float damage = 10;
    [SerializeField]
    bool isBoss = false;
    float baseHealth;
	// Use this for initialization
	void Start () {
        baseHealth = health;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //kills when health is zero
        if (health <= 0)
            Kill();
	}
    //the damage value subtracts from 100
    //this script calculates a damage value in a percent to use as a decimal
    public void TakeDamage(float damage)
    {
        health = ((health * 100) - damage) / 100;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //damages the player and kills the enemy on colision
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().DamageHealth(damage);
            if(!isBoss)
                Kill();
        }
    }
    //kills the enemy and all it's childeren and parents. not as morbid as it sounds, but whatever floats your boat is fine.
    public void Kill()
    {
        foreach (Transform obj in gameObject.GetComponentsInChildren<Transform>())
            Destroy(obj.gameObject);
        foreach (Transform obj in gameObject.GetComponentsInParent<Transform>())
            Destroy(obj.gameObject);
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetBaseHealth()
    {
        return baseHealth;
    }
}
