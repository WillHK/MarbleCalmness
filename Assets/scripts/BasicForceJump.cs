using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicForceJump : MonoBehaviour
{
    Rigidbody myRB;

    [SerializeField] InputAction JumpInput;

    [SerializeField] float jumpForce;

    private void OnEnable()
    {
        JumpInput.performed += Jump;
        JumpInput.Enable();
    }

    private void OnDisable()
    {
        JumpInput.performed -= Jump;
        JumpInput.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        bool isGrounded = false;
        if (Physics.Raycast(transform.position, Vector3.down, transform.localScale.y/2 + .1f))
        {
            isGrounded = true;
        }

        if (!isGrounded)
        {
            return;
        }

        if (obj.ReadValue<float>() > 0)
        {
            myRB.AddForce(0, jumpForce, 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
