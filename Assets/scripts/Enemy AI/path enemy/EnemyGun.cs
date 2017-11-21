using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    bool continueRunning = true;
    enum BulletType
    {
        BasicForwardShot, SlowLargeShot, BulletExplosion, StreamShot
    }
    [SerializeField]
    BulletType attackPattern = new BulletType();
    [SerializeField]
    GameObject basicForwardShot, slowLargeShot, bulletExplosion, streamShot;
    bool hasPathFinder;
	// Use this for initialization
	void Start () {
        hasPathFinder = (!gameObject.GetComponentInParent<PathFinder>().Equals(null));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if((!hasPathFinder)||(hasPathFinder&& gameObject.GetComponentInParent<PathFinder>().IsFiring()))
        if (continueRunning)
        {
            if (attackPattern == BulletType.BasicForwardShot)
            {
                StartCoroutine((WaitForTime(.25f)));
                Shoot(basicForwardShot);
            }else if(attackPattern == BulletType.SlowLargeShot)
            {
                StartCoroutine((WaitForTime(.5f)));
                Shoot(slowLargeShot);
            }else if(attackPattern == BulletType.BulletExplosion)
                {
                    StartCoroutine((WaitForTime(1f)));
                    Shoot(bulletExplosion);
            }else if(attackPattern == BulletType.StreamShot)
                {
                    StartCoroutine((WaitForTime(.25f)));
                    Shoot(streamShot);
                }
        }
	}
    void Shoot(GameObject g)
    {
        Instantiate(g,gameObject.transform.position,gameObject.transform.rotation);
    }
    IEnumerator WaitForTime(float timeToWait)
    {
        continueRunning = false;
        yield return new WaitForSeconds(timeToWait);
        continueRunning = true;
    }
}
