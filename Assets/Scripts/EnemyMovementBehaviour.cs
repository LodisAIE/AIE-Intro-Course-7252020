using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour {
    public Transform playerTransform;
    public Vector3 direction;
    public Vector3 velocity;
    public float maxSpeed;
    [SerializeField]
    private int damageAmount;
	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HealthBehaviour playerHealthScript = collision.gameObject.GetComponent<HealthBehaviour>();
            playerHealthScript.TakeDamage(damageAmount);
        }
    }
    // Update is called once per frame
    void Update () {
        if(playerTransform == null)
        {
            return;
        }
        //this gets us our direction by subtracting our positions
        direction = playerTransform.position - transform.position;
        //scales the normalized direction by our speed.
        //Subtracts current velocity from it for smooth movement
        velocity = (direction.normalized * maxSpeed) - velocity;
        //clamp to max speed if it goes over
        if(velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        //add velocity to position
        transform.position += velocity * Time.deltaTime;
        transform.LookAt(playerTransform);
	}
}
