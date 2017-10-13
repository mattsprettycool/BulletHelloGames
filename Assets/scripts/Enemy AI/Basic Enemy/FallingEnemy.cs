using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour {
    [SerializeField]
    float speed;
    float yVal;
    // Use this for initialization
    void Start () {
        yVal = gameObject.transform.position.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        yVal -= speed;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, yVal);
        Vector3 boundsMin = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMin, Camera.main.pixelRect.yMin, 0));
        if (yVal < boundsMin.y) Destroy(gameObject);
    }
}
