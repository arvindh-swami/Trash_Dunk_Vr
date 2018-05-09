using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour {

    float lastZ;
    float currentZ;

	// Use this for initialization
	void Start () {
        lastZ = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentZ = transform.position.z;
        if ((currentZ - lastZ) > 0)
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        } else
        {
            transform.RotateAround(transform.position, -transform.up, Time.deltaTime * 90f);
        }
        lastZ = currentZ;
	}
}
