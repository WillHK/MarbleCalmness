using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public float maxAcceleration = 20.0f;
    public GameObject deadMarble;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) 
    {

        Debug.Log(other.relativeVelocity.magnitude);
        if (other.relativeVelocity.magnitude > 25) {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(deadMarble, pos, rot);
            Destroy(gameObject);
        }
    }
}
