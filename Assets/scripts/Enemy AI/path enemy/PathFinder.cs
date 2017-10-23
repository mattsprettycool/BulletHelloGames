using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
//master script in the empty parent
public class PathFinder : MonoBehaviour {
    //array of the path locations that are childeren
    [SerializeField]
    PathLocation[] points;
    //the array's size and the current location in the array
    int arrSize = 0, curSpot = 1;
    //the x value of the enemy that gets inputed into the slope intercept equation
    float lineSpot;
    //the enemy effected by this script
    GameObject enemyToEffect;
    //the starting location of the enemy
    Vector2 startLocation;
    bool continueRunning = true;
    // Use this for initialization
    void Start () {
        //finds the enemy object
        foreach(Transform obj in gameObject.GetComponentsInChildren<Transform>())
        {
            if (obj.gameObject.tag.Equals("enemy"))
                enemyToEffect = obj.gameObject;
        }
        //sets the start location of the enemy
        startLocation = new Vector2(enemyToEffect.transform.position.x, enemyToEffect.transform.position.y);
        //sets the array size based on the ammount of path locations
        foreach (PathLocation obj in gameObject.GetComponentsInChildren<PathLocation>())
        {
            arrSize++;
        }
        points = new PathLocation[arrSize];
        //puts all path locations in the array
        int i = 0;
        foreach (PathLocation obj in gameObject.GetComponentsInChildren<PathLocation>())
        {
            points[i] = obj;
            i++;
        }
        //sets linespot to the starting location
        lineSpot = enemyToEffect.transform.position.x;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //checks if the path order is in the array's size
        if (curSpot < arrSize+1 && continueRunning)
        {
            //checks if the enemy's x is greater than or equal to the path to go to, because it needs to know to either add or subtract the x value
            //as these two nests are nearly identical, I am only going to comment this one
            if (startLocation.x >= ChoosePoint(curSpot).GetPoint().x)
            {
                //checks if the enemy is on the point of the path
                if (new Vector2(enemyToEffect.transform.position.x, enemyToEffect.transform.position.y) == ChoosePoint(curSpot).GetPoint())
                {
                    //The time that the enemy will stay in place before doing anything else related to movement.
                    StartCoroutine((WaitForTime(ChoosePoint(curSpot).GetWaitTime())));
                    //if the kill boolean is true, the enemy is killed.
                    if (ChoosePoint(curSpot).IsDeadOnPath())
                        enemyToEffect.GetComponent<BasicEnemy>().Kill();
                    //iterates the current spot
                    curSpot++;
                    //changes the start location to the new one
                    startLocation = new Vector2(enemyToEffect.transform.position.x, enemyToEffect.transform.position.y);
                }//if the enemy is to the left of the path, it runs this code
                else if (enemyToEffect.transform.position.x > ChoosePoint(curSpot).GetPoint().x)
                {
                    //gets the slope of the line that is from the enemy to the point. This whole code utilizes slope intercept form to move the enemy
                    float slope = (ChoosePoint(curSpot).GetPoint().y - enemyToEffect.transform.position.y) / (ChoosePoint(curSpot).GetPoint().x - enemyToEffect.transform.position.x);
                    //finds the y intercept by plugging in the path point. This is used to finish off the slope intercept form equation
                    float yIntercept = ChoosePoint(curSpot).GetPoint().y - (slope * ChoosePoint(curSpot).GetPoint().x);
                    //sets the locations to the new x value and the new y value that came from the equation
                    Vector2 pointToGoTo = new Vector2(lineSpot, (slope * lineSpot) + yIntercept);
                    //moves the enemy to the new location
                    enemyToEffect.transform.position = new Vector3(pointToGoTo.x, pointToGoTo.y, enemyToEffect.transform.position.z);
                    //moves the linespot based on the speed value to get the next point to plug in
                    lineSpot -= .1f * ChoosePoint(curSpot).GetSpeed();
                    //if the enemy overshot the path, this sets the enemy's position to the path. This isn't noticeable because the difference is usually in the hundereths place.
                    if(enemyToEffect.transform.position.x < ChoosePoint(curSpot).GetPoint().x)
                        enemyToEffect.transform.position = new Vector3(ChoosePoint(curSpot).GetPoint().x, ChoosePoint(curSpot).GetPoint().y, enemyToEffect.transform.position.z);
                }
                //again, as this code mirrors the code above, I won't be going over it. It is just for when the enemy is on the left of the point rather than the right
            }else if (startLocation.x < ChoosePoint(curSpot).GetPoint().x)
            {
                if (new Vector2(enemyToEffect.transform.position.x, enemyToEffect.transform.position.y) == ChoosePoint(curSpot).GetPoint())
                {
                    StartCoroutine((WaitForTime(ChoosePoint(curSpot).GetWaitTime())));
                    if (ChoosePoint(curSpot).IsDeadOnPath())
                        enemyToEffect.GetComponent<BasicEnemy>().Kill();
                    curSpot++;
                    startLocation = new Vector2(enemyToEffect.transform.position.x, enemyToEffect.transform.position.y);
                }
                else if (enemyToEffect.transform.position.x < ChoosePoint(curSpot).GetPoint().x)
                {
                    float slope = (ChoosePoint(curSpot).GetPoint().y - enemyToEffect.transform.position.y) / (ChoosePoint(curSpot).GetPoint().x - enemyToEffect.transform.position.x);
                    float yIntercept = ChoosePoint(curSpot).GetPoint().y - (slope * ChoosePoint(curSpot).GetPoint().x);
                    Vector2 pointToGoTo = new Vector2(lineSpot, (slope * lineSpot) + yIntercept);
                    enemyToEffect.transform.position = new Vector3(pointToGoTo.x, pointToGoTo.y, enemyToEffect.transform.position.z);
                    lineSpot += .1f * ChoosePoint(curSpot).GetSpeed();
                    if (enemyToEffect.transform.position.x > ChoosePoint(curSpot).GetPoint().x)
                        enemyToEffect.transform.position = new Vector3(ChoosePoint(curSpot).GetPoint().x, ChoosePoint(curSpot).GetPoint().y, enemyToEffect.transform.position.z);
                }
            }
        }
	}
    //finds the correct point in the array to use for the slope intercept equation
    PathLocation ChoosePoint(int spot)
    {
        foreach(PathLocation obj in points)
        {
            if (spot == obj.GetOrder())
                return obj;
        }
        return null;
    }
    //waits for timeToWait seconds
    IEnumerator WaitForTime(float timeToWait)
    {
        continueRunning = false;
        yield return new WaitForSeconds(timeToWait);
        continueRunning = true;
    }
}
