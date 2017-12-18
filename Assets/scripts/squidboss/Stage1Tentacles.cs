using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Tentacles : MonoBehaviour {
    float speed;
    TentacleManager tm;
    [SerializeField]
    bool isOnLeft;
    Vector3 defaultPos;
    bool justRespawned = true;
    [SerializeField]
    float damage = 10f;
    float distanceForLeft = 0;
	// Use this for initialization
	void Start () {
        if (isOnLeft)
        {
            distanceForLeft = transform.position.y - GameObject.FindGameObjectWithTag("rightTent").transform.position.y;
        }
        if (isOnLeft)
        {
            gameObject.transform.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x + 500 + Random.Range(0, 500), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x + 500 + Random.Range(0, 500), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        tm = GameObject.FindGameObjectWithTag("TentacleManager").GetComponent<TentacleManager>();
        speed = tm.GetSpeed();
        defaultPos = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
            speed = tm.GetSpeed();
            gameObject.transform.Translate(new Vector3(0, speed, 0));
            if (gameObject.transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
            {
                gameObject.transform.localScale = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, 0)).x + 500 + Random.Range(0, 500), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0)).y, gameObject.transform.position.z);
                justRespawned = true;
            }
        if (isOnLeft&&(distanceForLeft = transform.position.y - GameObject.FindGameObjectWithTag("rightTent").transform.position.y) > distanceForLeft)
        {
            transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("rightTent").transform.position.y + distanceForLeft, transform.position.z);
        }else if(isOnLeft && (distanceForLeft = transform.position.y - GameObject.FindGameObjectWithTag("rightTent").transform.position.y) < distanceForLeft)
        {
            transform.position = new Vector3(transform.position.x, GameObject.FindGameObjectWithTag("rightTent").transform.position.y - distanceForLeft, transform.position.z);
        }
	}
    public float GetDefPosY()
    {
        return defaultPos.y;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player") && justRespawned)
        {
            collision.collider.GetComponent<PlayerHealth>().DamageHealth(damage);
            justRespawned = false;
        }
    }
}
