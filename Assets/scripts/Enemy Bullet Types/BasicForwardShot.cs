using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class BasicForwardShot : MonoBehaviour {
    float yVal;
    [SerializeField]
    float speed;
    [SerializeField]
    float damage;
    // Use this for initialization
    void Start () {
        yVal = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //increases the yvalue and then kills the bullet if it's at the top of the screen
        yVal -= speed;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, yVal);
        if (yVal < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().DamageHealth(damage);
            Destroy(gameObject);
        }
    }
}
