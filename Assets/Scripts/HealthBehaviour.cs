using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour {
    [SerializeField]
    private int health;
    [SerializeField]
    private bool isAlive;
	// Use this for initialization
	void Start () {
		
	}
    public int GetHealth()
    {
        return health;
    }
	public void TakeDamage(int damageVal)
    {
        health -= damageVal;
        if(health <= 0)
        {
            isAlive = false;
        } 
    }
	// Update is called once per frame
	void Update () {
        if(isAlive == false)
        {
            GameObject temp = gameObject;
            Destroy(temp);
        }
	}
}
