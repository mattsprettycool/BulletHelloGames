using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Tentacles : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.localScale = new Vector3(Camera.main.pixelWidth, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        gameObject.transform.position = new Vector3(- 1 * (Camera.main.pixelWidth / 2), gameObject.transform.position.y, gameObject.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
