using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
    public int damageAmount;
    public string owner;
    public float despawnTime;
	// Use this for initialization
	void Start () {
        GameObject temp = gameObject;
        Destroy(temp, despawnTime);
    }
    private void Destroy()
    {
        GameObject temp = gameObject;
        Destroy(temp);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(owner) == false)
        {
            HealthBehaviour healthScript = other.GetComponent<HealthBehaviour>();
            if(healthScript == null)
            {
                Destroy();
                return;
            }
            healthScript.TakeDamage(damageAmount);
            Destroy();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
