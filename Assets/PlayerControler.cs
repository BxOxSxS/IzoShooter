using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{

    Vector2 inputVector;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
  
    }

    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();

    }

    private void FixedUpdate()
    {
        if(inputVector.y == 0)
        {
            rb.velocity = Vector2.zero;
        } else
        {
            Vector3 movment = transform.forward * inputVector.y;
            rb.AddForce(movment, ForceMode.Impulse);
        }
        if(inputVector.x == 0)
        {
            rb.angularVelocity = Vector3.zero;
        } else
        {
            Vector3 rotation = transform.up * inputVector.x;
            rb.AddTorque(rotation, ForceMode.Impulse);
        }
    }
}
