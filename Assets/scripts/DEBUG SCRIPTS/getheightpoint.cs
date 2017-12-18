using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getheightpoint : MonoBehaviour {
    [SerializeField]
    bool isToWorld = false;
    [SerializeField]
    bool isWidth = false;
	// Use this for initialization
	void Start () {
        if (isToWorld&&!isWidth)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y, transform.position.z);
        }
        else if(!isWidth)
            transform.position = new Vector3(transform.position.x, Camera.main.pixelHeight, transform.position.z);
        if (isWidth)
        {
            
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y, transform.position.z);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
