using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBoss : MonoBehaviour {
    [SerializeField]
    bool isStage2 = true;
    bool stopUpdate = false;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    int fireRate = 5;
    float currentFire = 0;
    [SerializeField]
    GameObject pointer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStage2&&!stopUpdate)
        {
            fireRate /= 2;
            stopUpdate = true;
        }
        if (currentFire < fireRate)
        {
            currentFire += Time.deltaTime;
        }
        else
        {
            currentFire = 0;
            var myInst =  Instantiate(bullet, transform);
            myInst.transform.parent = null;
        }
        if(transform.position != pointer.transform.position)
        {
            if(pointer.transform.position.x > transform.position.x)
            {
                transform.Translate(4, 0, 0);
            }else
                transform.Translate(-4, 0, 0);
        }
	}
    public void SetStage(bool isStage2Bool)
    {
        isStage2 = isStage2Bool;
    }
}
