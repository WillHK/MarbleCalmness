using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicForceMovement : MonoBehaviour
{

    public Rigidbody myRB;

    [SerializeField] InputAction WASDInput;
    Vector2 movementInput;
    public Transform orientation;
    [SerializeField] float force;
    [SerializeField] float topXZSpeed;
    [SerializeField] float topYSpeed;

    private void OnEnable()
    {
        WASDInput.Enable();
    }

    private void OnDisable()
    {
        WASDInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (topYSpeed > 0)
        {
            topYSpeed *= -1;
        }
        myRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        myRB.AddForce(new Vector3(movementInput.x, 0, movementInput.y) * force);

        if (myRB.velocity.y < topYSpeed)
        {
            myRB.velocity = new Vector3(myRB.velocity.x, topYSpeed, myRB.velocity.z);
        }
        Vector2 tempXZ = new Vector2(myRB.velocity.x, myRB.velocity.z);
        if (tempXZ.magnitude > topXZSpeed)
        {
            tempXZ = tempXZ.normalized * topXZSpeed;
            myRB.velocity = new Vector3(tempXZ.x, myRB.velocity.y, tempXZ.y); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        movementInput = WASDInput.ReadValue<Vector2>();
    }
}
