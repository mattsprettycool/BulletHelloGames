using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Tentacles : MonoBehaviour {
    float speed;
    TentacleManager tm;
    [SerializeField]
    bool isOnLeft;
    Vector3 defaultPos;
    [SerializeField]
    GameObject oppositeTentacle;
    bool justRespawned = false;
	// Use this for initialization
	void Start () {
        if (isOnLeft)
        {
            gameObject.transform.localScale = new Vector3(Camera.main.pixelWidth, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.position = new Vector3(-1 * (Camera.main.pixelWidth / 2), gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(Camera.main.pixelWidth, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.position = new Vector3((Camera.main.pixelWidth / 2), gameObject.transform.position.y, gameObject.transform.position.z);
        }
        tm = GameObject.FindGameObjectWithTag("TentacleManager").GetComponent<TentacleManager>();
        speed = tm.GetSpeed();
        defaultPos = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        speed = tm.GetSpeed();
        gameObject.transform.Translate(new Vector3(0, speed, 0));
        if (gameObject.transform.position.y <= -defaultPos.y)
        {
            gameObject.transform.localScale = new Vector3(Camera.main.pixelWidth + Random.Range(0, 100), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, oppositeTentacle.GetComponent<Stage1Tentacles>().GetDefPosY(), gameObject.transform.position.z);
        }
	}
    public float GetDefPosY()
    {
        return defaultPos.y;
    }
}
