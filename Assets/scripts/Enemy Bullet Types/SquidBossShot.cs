using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBossShot : MonoBehaviour {
    [SerializeField, Range(100, 1000)]
    int radius = 150;
    bool isInPlace = false;
    [SerializeField]
    float speed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isInPlace)
        {
            SquidBossBullet[] bullets = gameObject.GetComponentsInChildren<SquidBossBullet>();
            foreach (SquidBossBullet obj in bullets)
            {
                isInPlace = true;
                if (!obj.IsInPlace()) isInPlace = false;
            }
        }
        else
        {
            //transform.Rotate(new Vector3(0, 0, 1));
            gameObject.transform.Translate(new Vector3(0, -Mathf.Round(speed), 0));
        }
        if(transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y * 2)
        {
            Destroy(gameObject);
        }
    }
    public int GetRadius()
    {
        return radius;
    }
}
