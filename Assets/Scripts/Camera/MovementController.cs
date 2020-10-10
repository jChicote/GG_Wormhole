using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    public float speed;
    public float rotationspeed = 2;

    private Vector3 movementVector;
    private float forwardSpeed;
    private float yawSpeed;
    private float elevationSpeed;

    private bool isMoving;

    void Awake()
    {
        movementVector = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        transform.position += transform.forward * forwardSpeed * speed * Time.fixedDeltaTime;
        transform.position += transform.right * yawSpeed * rotationspeed * Time.fixedDeltaTime;
        transform.position += transform.up * elevationSpeed * rotationspeed * Time.fixedDeltaTime;
    }

    private void OnMovement(InputValue value)
    {
        forwardSpeed = value.Get<Vector2>().y;
        yawSpeed = value.Get<Vector2>().x;

    }

    private void OnElevation(InputValue value)
    {
        elevationSpeed = value.Get<float>();
    }
}
