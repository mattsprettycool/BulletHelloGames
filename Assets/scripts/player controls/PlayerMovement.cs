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
        Vector3 boundsMax = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMax, Camera.main.pixelRect.yMax, 0));
        Vector3 boundsMin = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMin, Camera.main.pixelRect.yMin, 0));
        if (yPos > boundsMax.y) yPos = boundsMax.y;
        if (xPos > boundsMax.x) xPos = boundsMax.x;
        if (yPos < boundsMin.y) yPos = boundsMin.y;
        if (xPos < boundsMin.x) xPos = boundsMin.x;
        gameObject.transform.position = new Vector2(xPos, yPos);
    }
}
