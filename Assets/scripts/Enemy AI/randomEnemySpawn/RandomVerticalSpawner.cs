using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVerticalSpawner : MonoBehaviour {
    [SerializeField]
    GameObject objToSpawn;
    [SerializeField, Range(100,200)]
    int intervalBetweenSpawns;
    int curTime;
    private void Start()
    {
        curTime = intervalBetweenSpawns;
    }
    // Update is called once per frame
    void Update () {
        if (curTime <= 0)
        {
            Vector3 randomPoint = new Vector3(Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x), transform.position.y, transform.position.z);
            Instantiate(objToSpawn, randomPoint, objToSpawn.transform.rotation);
            curTime = intervalBetweenSpawns;
        }
        else
            curTime--;
	}
}
