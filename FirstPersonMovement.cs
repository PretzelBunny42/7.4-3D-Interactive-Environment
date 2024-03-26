using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//THIS IS FOR VERSION 2

public class FirstPersonMovement : MonoBehaviour
{
    public Vector3 direction;
    public float rotateSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
//        transform.Translate(direction * rotateSpeed * Time.deltaTime);
        rb.transform.Translate(direction * rotateSpeed * Time.deltaTime);
    }

    public void OnPlayerMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        direction.x = inputVector.x;
        direction.z = inputVector.y;
    }

    public void OnCollisionStay(Collision collision)
    {
       foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 normal = contact.normal;
            normal.y = 0; ;
            direction -= Vector3.Project(direction, normal);
        }
       
    }

    /*
    public float moveSpeed = 5f;
    public float rotateSpeed = 3f;

    private Vector3 movement;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(movement * rotateSpeed * Time.deltaTime);
    }

    public void OnPlayerMove(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        movement.x = inputVector.x;
        movement.z = inputVector.y;

    }

    */

}
