using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ballshooter : MonoBehaviour
{
    public Rigidbody ProjectilePrefab;
    public float ProjectileForce = 1000.0f;

    private DateTime LastProjectileClearing = DateTime.Now;

    private int MinimumSecondsToClear = 5;
    private int ProjectileLifetimeSeconds = 60;

    private Dictionary<DateTime,List<GameObject>> ProjectileCollection = new Dictionary<DateTime,List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if mouse is down
        if (Input.GetMouseButtonDown (0))
        { 
            // shoot a ray to mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // create a new projectile ball
            Rigidbody r = Instantiate(ProjectilePrefab);
            r.gameObject.transform.position = ray.origin;
            // shoot projectile ball in direction of ray
            r.AddForce(ray.direction * ProjectileForce, ForceMode.Acceleration);
            DateTime spawnTime = DateTime.Now;
            if(ProjectileCollection.ContainsKey(spawnTime) == false)
            {
                ProjectileCollection[spawnTime] = new List<GameObject>();
            }

            ProjectileCollection[spawnTime].Add(r.gameObject);
        }

        if ((DateTime.Now - LastProjectileClearing).TotalSeconds >= MinimumSecondsToClear)
        {
            ClearOldProjectiles();
        }
    }

    private void ClearOldProjectiles()
    {
        LastProjectileClearing = DateTime.Now;
        List<DateTime> ProjectileKeys = new List<DateTime>(ProjectileCollection.Keys);

        foreach(DateTime projectileTime in ProjectileKeys)
        {
            if ((DateTime.Now - projectileTime).TotalSeconds > ProjectileLifetimeSeconds)
            {
                Debug.Log("Clearing projectiles for " + projectileTime);
                foreach (GameObject projectile in ProjectileCollection[projectileTime])
                {
                    Destroy(projectile);
                }
                ProjectileCollection.Remove(projectileTime);
            }
        }
    }
}
