using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRaycastDistance;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource movementSound;
    [SerializeField] private AudioClip movementClip;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSound.clip = movementClip;
        movementSound.loop = true;
        movementSound.Stop();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);

        if (movement.magnitude > 0)
        {
            if (!movementSound.isPlaying)
            {
                movementSound.Play();
            }
        }
        else
        {
            movementSound.Stop();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
                jumpSound.Play();
                movementSound.Stop();
            }
        }
        else
        {
            if (IsGrounded() && !movementSound.isPlaying)
            {
                movementSound.Play();
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, jumpRaycastDistance);
    }
}