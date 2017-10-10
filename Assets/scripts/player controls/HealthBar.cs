using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    [SerializeField, Range(0.0f, 1.0f)]
    float health;
    float rectHeight;
	// Use this for initialization
	void Start () {
        rectHeight = gameObject.GetComponent<RectTransform>().rect.height;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().rect.width, rectHeight * health);
	}
    public float GetHealth()
    {
        return health;
    }
    public void DamageHealth(float damageTaken)
    {
        health -= damageTaken;
    }
}
