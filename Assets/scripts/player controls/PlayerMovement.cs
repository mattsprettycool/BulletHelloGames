using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float yPos, xPos;
    [SerializeField]
    float speed;
	// Use this for initialization
	void Start () {
        yPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        yPos += speed* Input.GetAxis("Vertical");
        xPos += speed * Input.GetAxis("Horizontal");
        gameObject.transform.position = new Vector2(xPos, yPos);
    }
}
