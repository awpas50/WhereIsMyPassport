using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    Rigidbody2D rb;
    public float walkSpeed;
    public float sprintSpeed;
    private float currentSpeed;
    //private float maxSpeed;
    Vector2 movement;
    
    public GameObject playerRef;

    //[Header("Lock player in the camera")]
    //private Vector2 screenBounds;
    //private float objWidth;
    //private float objHeight;

    public Vector2 screenPos;

    Vector3 viewPortPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = walkSpeed;
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
    
    void Update()
    {
        DetectDirection();
        screenPos = Camera.main.WorldToViewportPoint(transform.position);
        //float hMoveSpeed = 3f;
        //float vMoveSpeed = 5f;

        //float hMovement = Input.GetAxis("Horizontal") * hMoveSpeed;
        //float vMovement = Input.GetAxis("Vertical") * vMoveSpeed;

        //transform.Translate(new Vector3(hMovement, vMovement, 0));
        //if (movement.magnitude > 1)
        //{
        //    movement = movement.normalized;
        //}
    }

    void DetectDirection()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
