using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{
    public Camera mainCam;
    [SerializeField]
    private BulletEmitterBehaviour gun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this creates a horizontal plane passing through this object's center
        Plane plane = new Plane(Vector3.up, transform.position);
        // create a ray from the mousePosition
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance = 0;
        if (plane.Raycast(ray, out distance))
        {
            // some point of the plane was hit - get its coordinates
            Vector3 hitPoint = ray.GetPoint(distance);
            transform.LookAt(hitPoint);
            // use the hitPoint to aim your cannon
        }
        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
        }
    }
}
