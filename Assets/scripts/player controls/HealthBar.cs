using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Author: Matt Braden
public class HealthBar : MonoBehaviour {
    //the player's health
    [SerializeField, Range(0.0f, 1.0f)]
    float health;
    float rectHeight;
	// Use this for initialization
	void Start () {
        rectHeight = gameObject.GetComponent<RectTransform>().rect.height;
    }
	
	// Update is called once per frame
	void Update () {
        //changes the rect height based on the health
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().rect.width, rectHeight * health);
	}
    //allows other classes to reference player health
    public float GetHealth()
    {
        return health;
    }
    //damages the health
    public void DamageHealth(float damageTaken)
    {
        bool endGame = false;
        health = ((health * 100) - damageTaken) / 100;
        if(health <= 0)
        {
            endGame = true;
        }
        if (endGame)
        {
            SceneManager.LoadScene("End Game", LoadSceneMode.Additive);
        }
    }
}
