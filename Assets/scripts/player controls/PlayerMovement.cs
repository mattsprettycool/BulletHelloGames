using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    float yPos, xPos;
    [SerializeField]
    float speed;
    float momentumX, momentumY;
    // Use this for initialization
    void Start () {
        yPos = gameObject.transform.position.y;
        xPos = gameObject.transform.position.x;
        momentumX = 0;
        momentumY = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        {
            yPos += (speed * Input.GetAxis("Vertical") * .5f)/1.5f;
            xPos += (speed * Input.GetAxis("Horizontal") * .5f)/1.5f;
        }
        else
        {
            yPos += speed * Input.GetAxis("Vertical") * .5f;
            xPos += speed * Input.GetAxis("Horizontal") * .5f;
        }
        
        Vector3 boundsMax = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMax, Camera.main.pixelRect.yMax, 0));
        Vector3 boundsMin = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMin, Camera.main.pixelRect.yMin, 0));
        if (yPos > boundsMax.y) yPos = boundsMax.y;
        if (xPos > boundsMax.x) xPos = boundsMax.x;
        if (yPos < boundsMin.y) yPos = boundsMin.y;
        if (xPos < boundsMin.x) xPos = boundsMin.x;
        //DEBUG PURPOSES ONLY
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
        gameObject.transform.position = new Vector2(xPos, yPos);
    }
    public Vector2 SendMomentum()
    {
        momentumY = speed * Input.GetAxis("Vertical");
        momentumX = speed * Input.GetAxis("Horizontal");
        return new Vector2(momentumX, momentumY);
    }
}
