using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float yVal;
    [SerializeField]
    float speed;
	// Use this for initialization
	void Start () {
        yVal = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        yVal += speed;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, yVal);
        if (yVal > Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y) Destroy(gameObject);
	}
}
