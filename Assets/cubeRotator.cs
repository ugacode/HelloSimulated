using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRotator : MonoBehaviour
{
    public int RotationSpeed = 65;
    // Update is called once per frame
    void Update()
    {
        // Dampen towards the target rotation
        transform.Rotate(RotationSpeed * Time.deltaTime,RotationSpeed * Time.deltaTime ,RotationSpeed * Time.deltaTime);
    }
}
