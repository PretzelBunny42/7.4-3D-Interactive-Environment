using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//THIS IS FOR VERSION 2

public class FirstPersonCamera : MonoBehaviour
{

    public Camera playerCamera;

    public float deltaX;
    public float deltaY;

    public float xRot;
    public float yRot;

    public float speed; // Adjust the mouse sensitivity here
    public float rotationSpeed; // Adjust the rotation speed here

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        Cursor.visible = true;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        yRot += deltaX;
        xRot -= deltaY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }
    */

    void Update()
    {
        // Adjust rotation based on input
        yRot += deltaX * speed;
        xRot -= deltaY * speed;

        // Clamp vertical rotation to limit it within -90 to 90 degrees
        xRot = Mathf.Clamp(xRot, -45f, 45f);

        // Smoothly interpolate the camera's local rotation
        Quaternion targetCameraRotation = Quaternion.Euler(xRot, 0, 0);
        playerCamera.transform.localRotation = Quaternion.Lerp(
            playerCamera.transform.localRotation,
            targetCameraRotation,
            Time.deltaTime * rotationSpeed);

        // Smoothly interpolate the player's rotation
        Quaternion targetPlayerRotation = Quaternion.Euler(0, yRot, 0);
        transform.rotation = Quaternion.Lerp(
                transform.rotation, targetPlayerRotation, Time.deltaTime * rotationSpeed);
    }
    public void OnCameraLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
