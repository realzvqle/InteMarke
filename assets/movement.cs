using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public Transform player;
    public float speed = 300;
    public float jumpHeight = 10;
    public Rigidbody rb;
    public Quaternion initialRotation;
    private bool isGrounded = true;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")).normalized;

        // Rotate the movement direction to align with the player's rotation
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply movement
        Vector3 movement = moveDirection * speed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(0, jumpHeight, 0);
        }
        if (Input.GetKeyDown("o"))
        {
            player.position = new Vector3(16, 1, 8);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = transform.position + transform.forward; 
            Instantiate(prefab, MousePosition, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }
}
// transform.position 
