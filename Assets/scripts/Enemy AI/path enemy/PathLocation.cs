using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
//the locations for each point
public class PathLocation : MonoBehaviour {
    //order of the path
    [SerializeField, Range(1, 100)]
    int pathOrder;
    //speed of the enemy on the path
    [SerializeField, Range(0f, 10.0f)]
    float speedToPath = 1;
    //if true, the enemy dies upon reaching the path
    [SerializeField]
    bool killOnGettingToPath = false;
    //gets the point of where the path is
    public Vector2 GetPoint()
    {
        return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
    //gets the path order
    public int GetOrder()
    {
        return pathOrder;
    }
    //gets the speed on the path
    public float GetSpeed()
    {
        return speedToPath;
    }
    //checks if the path kills the enemy
    public bool IsDeadOnPath()
    {
        return killOnGettingToPath;
    }
}
