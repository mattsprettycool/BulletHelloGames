using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class Bullet : MonoBehaviour {
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
        yVal += speed;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, yVal);
        if (yVal > Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) Destroy(gameObject);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroys the bullet and damages enemy health on enemy collision
        if (collision.collider.tag == "enemy")
        {
            collision.collider.gameObject.GetComponent<BasicEnemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    //sends the bullet's damages to other classes.
    public float SendDamage()
    {
        return damage;
    }
}
