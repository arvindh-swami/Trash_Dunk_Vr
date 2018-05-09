using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Vector3 direction;
    Rigidbody rb;
    public float force;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        direction = Camera.main.transform.forward;
        rb.velocity = force * new Vector3(direction.x, direction.y + .5f, direction.z);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fan")
        {
            if (other.transform.position.z < 3)
            {
                rb.AddForce(transform.forward * PlayerPrefs.GetInt("fanForce"));
            } else
            {
                rb.AddForce(-transform.forward * PlayerPrefs.GetInt("fanForce"));
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "fan")
        {
            if (other.transform.position.z < 3)
            {
                rb.AddForce(transform.forward * PlayerPrefs.GetInt("fanForce"));
            } else
            {
                rb.AddForce(-transform.forward * PlayerPrefs.GetInt("fanForce"));
            }
        }
    }
}
