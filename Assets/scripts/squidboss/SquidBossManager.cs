using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBossManager : MonoBehaviour {
    [SerializeField]
    GameObject[] stage1stuff;
    [SerializeField]
    GameObject[] stage2stuff;
    [SerializeField]
    GameObject[] stage3stuff;
    [SerializeField]
    float timeUntilStage2;
    bool changeStage = false;
    bool startChangeStage = true;
    [SerializeField]
    bool debugStage2 = false;
    bool onlyOncePls = true;
    // Update is called once per frame
    private void Start()
    {
        if (!debugStage2)
            CreateStage1();
    }
    void Update () {
        if (timeUntilStage2 <= 0&&!debugStage2 && onlyOncePls)
        {
            DestroyStage1();
            CreateStage2();
            onlyOncePls = false;
        }
        else
            timeUntilStage2 -= Time.deltaTime;
        if (debugStage2 && onlyOncePls)
        {
            CreateStage2();
            onlyOncePls = false;
        }
    }
    void DestroyStage1()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("STAGE1"))
            Destroy(obj);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pathfinder"))
            Destroy(obj);
        Destroy(GameObject.FindGameObjectWithTag("TentacleManager"));
    }
    void CreateStage1()
    {
        foreach (GameObject obj in stage1stuff)
            Instantiate(obj);
    }
    void CreateStage2()
    {
        foreach (GameObject obj in stage2stuff)
            Instantiate(obj);
    }
    void CreateStage3()
    {
        foreach (GameObject obj in stage3stuff)
            Instantiate(obj);
    }
}
