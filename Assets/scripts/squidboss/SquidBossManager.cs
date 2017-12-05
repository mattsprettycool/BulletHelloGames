using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBossManager : MonoBehaviour {
    [SerializeField]
    GameObject[] stage1Objs;
    [SerializeField]
    GameObject[] stage2Objs;
    [SerializeField]
    GameObject[] stage3Objs;
    [SerializeField]
    float timeUntilStage2;
    bool changeStage = false;
    bool startChangeStage = true;
	
	// Update is called once per frame
	void Update () {
        if (timeUntilStage2 <= 0)
        {
            DestroyStage1();
        }
        else
            timeUntilStage2 -= Time.deltaTime;
    }
    void DestroyStage1()
    {
        foreach (GameObject obj in stage1Objs)
            Destroy(obj);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pathfinder"))
            Destroy(obj);
    }
}
