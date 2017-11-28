using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleManager : MonoBehaviour {
    [SerializeField]
    float speed;
	// Use this for initialization
	void Start () {
        speed = -2;
	}
	
	// Update is called once per frame
	void Update () {
        if(speed>-9)
        speed -= Time.deltaTime;
	}

    public float GetSpeed()
    {
        return speed;
    }
}
