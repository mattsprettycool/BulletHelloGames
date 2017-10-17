using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//master script in the empty parent
public class PathFinder : MonoBehaviour {
    [SerializeField]
    PathLocation[] points;
    int arrSize = 0;
	// Use this for initialization
	void Start () {
        foreach (PathLocation obj in gameObject.GetComponentsInChildren<PathLocation>())
        {
            arrSize++;
        }
        points = new PathLocation[arrSize];
        int i = 0;
        foreach (PathLocation obj in gameObject.GetComponentsInChildren<PathLocation>())
        {
            points[i] = obj;
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
