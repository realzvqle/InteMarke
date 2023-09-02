using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform camara;
    public float sensitivity = 2.0f; // Mouse sensitivity for looking
    public float maxYRotation = 80.0f; // Maximum vertical rotation angle

    private float rotationX = 0.0f; // Current vertical rotation angle

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        camara.position = player.position;
        // Rotate the player (horizontal) based on horizontal mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        player.Rotate(Vector3.up * mouseX);

        // Rotate the camera (vertical) based on vertical mouse input
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -maxYRotation, maxYRotation); // Clamp vertical rotation to avoid over-rotation

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // Apply rotations to both player and camera
        player.localRotation = Quaternion.Euler(0, player.localRotation.eulerAngles.y, 0);
        camara.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}