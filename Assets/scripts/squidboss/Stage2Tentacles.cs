using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Tentacles : MonoBehaviour {
    Transform playerTransform;
    [SerializeField, Range(1,100)]
    int baseSpeed = 1;
    float speed = 0;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y > playerTransform.position.y && transform.position.y-baseSpeed > playerTransform.position.y)
        {
            if(speed >= -baseSpeed)
                speed -= .1f;
        }else if(transform.position.y < playerTransform.position.y && transform.position.y + baseSpeed < playerTransform.position.y)
        {
            if (speed <= baseSpeed)
                speed += .1f;
        }else if(transform.position.y == playerTransform.position.y)
        {
            speed = 0;
        }
        transform.Translate(0, speed, 0);
    }
}
