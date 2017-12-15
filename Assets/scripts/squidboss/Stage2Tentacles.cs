using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Tentacles : MonoBehaviour {
    Transform playerTransform;
    [SerializeField, Range(1,100)]
    int baseSpeed = 1;
    float speed = 0;
    [SerializeField, Range(1, 100)]
    int timeUntilAttack = 1;
    float attackTimer = 0;
    bool firedOnce = false;
    bool doAttack = false;
    float attackTime = 0;
    [SerializeField]
    bool leftSide = false;
    float xOrigin;
    int timesToPass = 10;
    [SerializeField]
    bool isStage2 = true;
    bool changeStage = false;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        xOrigin = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isStage2 && !changeStage)
        {
            baseSpeed *= 2;
            timeUntilAttack /= 2;
            changeStage = true;
        }
        if(transform.position.y > playerTransform.position.y && transform.position.y-baseSpeed > playerTransform.position.y && (!firedOnce || (firedOnce && !isStage2)))
        {
            if (!(speed <= -baseSpeed))
                speed -= .1f;
        }else if(transform.position.y < playerTransform.position.y && transform.position.y + baseSpeed < playerTransform.position.y && (!firedOnce || (firedOnce && !isStage2)))
        {
            if (!(speed >= baseSpeed))
                speed += .1f;
        }
        if (transform.position.y <= baseSpeed + playerTransform.position.y && transform.position.y >= playerTransform.position.y - baseSpeed && (!firedOnce || (firedOnce && !isStage2)))
            speed /= 1.25f;
        if (!firedOnce || (firedOnce && !isStage2))
        {
            transform.Translate(0, speed, 0);
        }
        else
            speed = 0;
        if(transform.position.y < -(Camera.main.pixelHeight/2))
        {
            transform.position = new Vector3(transform.position.x, -(Camera.main.pixelHeight / 2), transform.position.z);
        }
        if (transform.position.y > (Camera.main.pixelHeight / 2))
        {
            transform.position = new Vector3(transform.position.x, (Camera.main.pixelHeight / 2), transform.position.z);
        }
        if (attackTimer >= timeUntilAttack && !firedOnce)
        {
            firedOnce = true;
            doAttack = true;
        }
        else
            attackTimer += Time.deltaTime;

        if (doAttack)
        {
            if (attackTime <= 1)
            {
                attackTime += Time.deltaTime;
                if (attackTime < .5f)
                {
                    if (leftSide)
                    {
                        transform.Translate(-2, 0, 0);
                    }
                    else
                        transform.Translate(2, 0, 0);
                }else if(attackTime < 1)
                {
                    if (leftSide)
                    {
                        transform.Translate(13.25f, 0, 0);
                    }
                    else
                        transform.Translate(-13.25f, 0, 0);
                }
            }
            else if (timesToPass > 0)
            {
                float distanceToGo = 0;
                if (leftSide)
                {
                    distanceToGo = (transform.position.x - xOrigin)/timesToPass;
                    transform.Translate(-distanceToGo, 0, 0);
                    timesToPass--;
                }
                else
                {
                    distanceToGo = (xOrigin - transform.position.x) / timesToPass;
                    transform.Translate(distanceToGo, 0, 0);
                    timesToPass--;
                }
            }
            else
            {
                timesToPass = 10;
                firedOnce = false;
                doAttack = false;
                attackTime = 0;
                attackTimer = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().DamageHealth(15f);
        }
    }
    public void SetStage(bool isStage2Bool)
    {
        isStage2 = isStage2Bool;
    }
}
