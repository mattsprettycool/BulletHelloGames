using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Tentacles : MonoBehaviour {
    Transform playerTransform;
    [SerializeField, Range(1,100)]
    int baseSpeed = 1;
    float speed = 0;
    int debugTimesAttacked = 0;
    [SerializeField, Range(1, 100)]
    int timeUntilAttack = 1;
    float attackTimer = 0;
    bool firedOnce = false;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y > playerTransform.position.y && transform.position.y-baseSpeed > playerTransform.position.y && !firedOnce)
        {
            if (!(speed <= -baseSpeed))
                speed -= .1f;
        }else if(transform.position.y < playerTransform.position.y && transform.position.y + baseSpeed < playerTransform.position.y && !firedOnce)
        {
            if (!(speed >= baseSpeed))
                speed += .1f;
        }
        if (transform.position.y <= baseSpeed + playerTransform.position.y && transform.position.y >= playerTransform.position.y - baseSpeed && !firedOnce)
            speed /= 1.25f;
        if (!firedOnce)
        {
            transform.Translate(0, speed, 0);
        }
        else
            speed = 0;
            
        if (attackTimer >= timeUntilAttack && !firedOnce)
        {
            firedOnce = true;
            debugTimesAttacked++;
            Debug.Log("attacked for the " + debugTimesAttacked + " time.");
            DoAttack();
        }
        else
            attackTimer += Time.deltaTime;
    }
    void DoAttack()
    {
        float i = 0;
        while(i<=10)
        {
            i += Time.deltaTime;
        }
        firedOnce = false;
        attackTimer = 0;
    }
}
