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
        float cameraH = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, 0, 0)).x;
        float randomPos = Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x);
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
