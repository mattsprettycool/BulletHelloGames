using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    bool continueRunning = true;
    enum BulletType
    {
        BasicForwardShot, SlowLargeShot
    }
    [SerializeField]
    BulletType attackPattern = new BulletType();
    [SerializeField]
    GameObject basicForwardShot, slowLargeShot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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
