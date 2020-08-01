using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour {
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;
    private Vector3 currentVelocity;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        direction = Vector3.zero;
        //Check if input was recieved
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            //if input recieved change the direction we're moving in
            direction.x = 1;
        }
        else if(Input.GetAxisRaw("Horizontal") == -1)
        {
            direction.x = -1;
        }
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            //if input recieved change the direction we're moving in
            direction.z = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            direction.z = -1;
        }
        currentVelocity = direction * speed;
        if (currentVelocity.magnitude > maxSpeed) 
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        transform.position += currentVelocity *Time.deltaTime;
    }
}
