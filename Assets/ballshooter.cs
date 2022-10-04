using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballshooter : MonoBehaviour
{
    public Rigidbody ProjectilePrefab;
    public float ProjectileForce = 42.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if mouse is down
        if ( Input.GetMouseButtonDown (0))
        { 
            // shoot a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // create a new projectile ball
            Rigidbody r = Instantiate(ProjectilePrefab);
            r.gameObject.transform.position = ray.origin;
            // shoot projectile ball in direction of ray
            r.AddForce(ray.direction * ProjectileForce, ForceMode.Acceleration);
        }
    }
}
