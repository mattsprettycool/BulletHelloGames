using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBossBullet : MonoBehaviour {
    float yVal;
    [SerializeField]
    float speed;
    [SerializeField]
    float damage;
    int radiusFromParent;
    SquidBossShot parentScript;
    // Use this for initialization
    void Start()
    {
        yVal = gameObject.transform.position.y;
        parentScript = gameObject.GetComponentInParent<SquidBossShot>();
        radiusFromParent = parentScript.GetRadius();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.position = new Vector2(gameObject.transform.position.x,Mathf.Round(yVal));
        if (!(DistFromParent() >= radiusFromParent))
        {
            gameObject.transform.Translate(new Vector3(0, Mathf.Round(speed), 0));
        }
        else
            transform.RotateAround(transform.parent.position, new Vector3(0, 0, .5f), 1);
        if (yVal < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().DamageHealth(damage);
            Destroy(gameObject);
        }
    }
    private float DistFromParent()
    {
        return Mathf.Sqrt(Mathf.Pow(transform.localPosition.x, 2)+Mathf.Pow(transform.localPosition.y, 2));
    }
    public bool IsInPlace()
    {
        return (DistFromParent() >= radiusFromParent);
    }
}
