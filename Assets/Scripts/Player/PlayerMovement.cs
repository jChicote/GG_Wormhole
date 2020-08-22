using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;

    public float movementSpeed = 5f;
    public float rotationSpeed = 6f;
    public float mouseSensitivity = 1f;
    
    private Vector3 _movementVect = Vector3.zero;
    private Vector3 _rotationVect = Vector3.zero;
    private float _inputX = 0;
    private float _inputY = 0;

    private float _pitch = 0;
    private float _yaw = 0;

    Vector3 forwardForce;
    Vector3 rightForce;

    Vector3 playerYaw;
    Vector3 cameraPitch;

    void Awake()
    {
        mainCamera = this.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement() {
        if (_inputX == 0 && _inputY == 0)
        {
            _movementVect = Vector3.zero;
            transform.position += _movementVect;
            return;
        }
        else
        {
            forwardForce = transform.forward * _inputY * movementSpeed * Time.fixedDeltaTime;
            rightForce = transform.right * _inputX * movementSpeed * Time.fixedDeltaTime;

            _movementVect = forwardForce + rightForce;
        }

        transform.position += _movementVect;
    }

    void PerformRotation()
    {
        if (_pitch == 0 && _yaw == 0) return;

        //_rotationVect = Vector3.zero;
        playerYaw = new Vector3(0, _yaw, 0);
        cameraPitch = new Vector3(-1 * _pitch, 0, 0);
        mainCamera.transform.Rotate(cameraPitch);
        transform.Rotate(playerYaw);
    }

    void OnMovement(InputValue value)
    {
        _inputX = value.Get<Vector2>().x;
        _inputY = value.Get<Vector2>().y;
    }

    void OnHorizontal(InputValue value)
    {
        _inputX = value.Get<float>();
    }

    void OnVertical(InputValue value)
    {
        _inputY = value.Get<float>();
    }

    void OnMouseRotation(InputValue value) {
        //Debug.Log(value.Get<Vector2>());

        //_pitch = CalculateInputToCenter(value.Get<Vector2>().y, Screen.height, mouseSensitivity);
        //_yaw = CalculateInputToCenter(value.Get<Vector2>().x, Screen.width, mouseSensitivity);

        _pitch = value.Get<Vector2>().y;
        _yaw = value.Get<Vector2>().x;
    }

    private float CalculateInputToCenter(float inputVal, float screenAxis, float sensitivity)
    {
        return (inputVal - (screenAxis / 2)) / (screenAxis / 2) * sensitivity;
    }
}
