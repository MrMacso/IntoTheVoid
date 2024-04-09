using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] float _acceleration = 5f;
    [SerializeField] float _deceleration = 5f;
    [SerializeField] float _maxSpeed = 20f;
    Rigidbody _rb;
    PlayerInput _playerInput;
    PlayerControls _playerControls;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        _playerControls = new PlayerControls();
        _playerControls.Player.Enable();
        _playerControls.Player.Cast.performed += Cast_performed;
    }
    private void FixedUpdate()
    {
        Vector2 inputVector = _playerControls.Player.Movement.ReadValue<Vector2>();
        if(inputVector != Vector2.zero )
        {
            _rb.AddForce(new Vector3(inputVector.x, 0f, inputVector.y) * _acceleration, ForceMode.Force);

            if(_rb.velocity.magnitude > _maxSpeed)
            {
                _rb.velocity = _rb.velocity.normalized * _maxSpeed;
            }
            if(Vector3.Dot((Vector3)inputVector, _rb.velocity) < 0f )
            {
                _rb.AddForce(_rb.velocity * -_deceleration, ForceMode.Force);
            }
        }
        else
        {
            _rb.AddForce(_rb.velocity * - _deceleration, ForceMode.Force);
            
        }
    }

    private void Cast_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Cast " + context.phase);
        }
    }
}
