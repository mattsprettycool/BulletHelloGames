using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBossPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetRandomPos();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SetRandomPos()
    {
        int cameraH = Camera.main.pixelWidth / 2;
        int randomPos = Random.Range(-cameraH, cameraH);
        transform.position = new Vector3(randomPos, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetRandomPos();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        SetRandomPos();
    }
}
