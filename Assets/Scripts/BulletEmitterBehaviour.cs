using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitterBehaviour : MonoBehaviour {
    [SerializeField]
    private BulletBehaviour bullet;
    [SerializeField]
    private Vector3 bulletForce;
    private GameObject currentBullet;
    public float bulletSpeed;
	// Use this for initialization
	void Start () {
		
	}
	public void Shoot()
    {
        currentBullet = Instantiate(bullet.gameObject, transform.position, transform.rotation);
        currentBullet.GetComponent<BulletBehaviour>().owner = tag;
        Rigidbody bulletRigidbody = currentBullet.GetComponent<Rigidbody>();
        bulletForce = transform.forward * bulletSpeed;
        bulletRigidbody.AddForce(bulletForce, ForceMode.Impulse);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
