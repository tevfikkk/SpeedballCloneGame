using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : Singleton<BallMovement>
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 5f;

    private Rigidbody rb;
    private float moveInput; // The input value of the player
    private float currentMoveSpeed;

    public float MoveSpeed
    {
        get => currentMoveSpeed;
        set => currentMoveSpeed = value;
    }

    private void Start()
    {
        currentMoveSpeed = moveSpeed; // Set the current move speed to the move speed
    }

    protected override void Awake()
    {
        base.Awake();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // this is to move the ball forward
        rb.velocity += Vector3.forward * currentMoveSpeed * Time.fixedDeltaTime; // fixedDeltaTime is used to make the movement framerate independent
        //Move();
    }

    /// <summary>
    /// Unity event called when the player moves the ball
    /// it reads only the x value of the input
    /// </summary>
    public void MovementEvent(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>().x; // Get the input value via the callback context

        Move(moveInput);
    }

    /// <summary>
    /// Turn the ball by taking the input value and clamping it
    /// </summary>
    private void Move(float direction)
    {
        float pos = Mathf.Clamp(direction * turnSpeed, -turnSpeed, turnSpeed);
        Vector3 targetPosition = new Vector3(pos, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 5f);
    }
}
