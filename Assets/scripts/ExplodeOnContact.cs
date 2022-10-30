using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public GameObject deadMarble;
    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.tag);
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(deadMarble, pos, rot);
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
