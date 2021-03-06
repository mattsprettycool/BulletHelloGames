﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    Vector3 startpos;
    bool notAtStart = true;
	// Use this for initialization
	void Start () {
        pointer = GameObject.FindGameObjectWithTag("pointer");
        startpos = transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y+500, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (notAtStart)
        {
            transform.Translate(0, -5, 0);
            if (transform.position.y <= startpos.y)
                notAtStart = false;
        }else
        {
            if (gameObject.GetComponent<BasicEnemy>().GetHealth() <= 0)
                SceneManager.LoadScene("YouWin", LoadSceneMode.Single);
            if (!isStage2 && !stopUpdate)
            {
                fireRate /= 2;
                stopUpdate = true;
                var animator = gameObject.GetComponent<Animator>();
                animator.SetTrigger("red");
            }
            if (currentFire < fireRate)
            {
                currentFire += Time.deltaTime;
            }
            else
            {
                currentFire = 0;
                var myInst = Instantiate(bullet, transform);
                myInst.transform.parent = null;
            }
            if (transform.position != pointer.transform.position)
            {
                if (pointer.transform.position.x > transform.position.x)
                {
                    transform.Translate(4, 0, 0);
                }
                else
                    transform.Translate(-4, 0, 0);
            }
            if (gameObject.GetComponent<BasicEnemy>().GetHealth() <= gameObject.GetComponent<BasicEnemy>().GetBaseHealth() / 2)
            {
                isStage2 = false;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("tentStage2"))
                {
                    obj.GetComponent<Stage2Tentacles>().SetStage(false);
                }
            }
        }
	}
    public void SetStage(bool isStage2Bool)
    {
        isStage2 = isStage2Bool;
    }
}
