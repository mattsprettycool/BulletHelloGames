using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Matt Braden
public class PlayerHealth : MonoBehaviour {
    HealthBar hb;
    [SerializeField]
    float iFrameTime = 3;
    bool iframe = false;
    float iframereal;
    float blinkTime = .15f;
    float iframeblink;
    // Use this for initialization
    void Start () {
        //gets the health bar to mess with it from the player
        hb = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        iframereal = 0;
        iframeblink = blinkTime;
	}
	
	// Update is called once per frame
	void Update () {
        StartIFrames();
        if (iframe)
        {
            BlinkyIFrames();
        }else
            foreach (SpriteRenderer sp in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.enabled = true;
            }
    }
    //Damages the health from the player
    public void DamageHealth(float damage)
    {
        if (!iframe)
        {
            hb.DamageHealth(damage);
            if (iframereal <= 0)
                iframereal = iFrameTime;
        }
        
    }
    private void StartIFrames()
    {
        if (iframereal > 0)
        {
            iframe = true;
            iframereal -= Time.deltaTime;
        }
        else
        {
            iframe = false;
        }
    }
    private void BlinkyIFrames()
    {
        if(iframeblink > 0 || iframeblink <= -blinkTime)
        {
            if (iframeblink <= -blinkTime)
                iframeblink = blinkTime;
            foreach(SpriteRenderer sp in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.enabled = false;
            }
            iframeblink -= Time.deltaTime;
        }
        else
        {
            foreach (SpriteRenderer sp in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                sp.enabled = true;
            }
            iframeblink -= Time.deltaTime;
        }
    }
}
