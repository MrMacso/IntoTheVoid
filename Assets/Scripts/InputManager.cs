using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Player _player;
    Rigidbody _rb;
    PlayerControls _playerControls;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
            Debug.Log("Rigidby component not found!");

        _player= GetComponent<Player>();
        if (_player == null)
            Debug.Log("Player component not found!");

        _playerControls = new PlayerControls();
        _playerControls.Player.Enable();
        _playerControls.Player.Cast.performed += Cast_performed;
    }
    void FixedUpdate()
    {
        MovementInput();
    }

    void MovementInput()
    {
        if (_player == null || _rb == null)
            return;

        Vector2 inputVector = _playerControls.Player.Movement.ReadValue<Vector2>();
        if (inputVector != Vector2.zero)
        {
            _rb.AddForce(new Vector3(inputVector.x, 0f, inputVector.y) * _player.GetAcceleration(), ForceMode.Force);

            if (_rb.linearVelocity.magnitude > _player.GetMaxSpeed())
            {
                _rb.linearVelocity = _rb.linearVelocity.normalized * _player.GetMaxSpeed();
            }
            if (Vector3.Dot((Vector3)inputVector, _rb.linearVelocity) < 0f)
            {
                _rb.AddForce(_rb.linearVelocity * -_player.GetDeceleration(), ForceMode.Force);
            }
        }
        else
            _rb.AddForce(_rb.linearVelocity * -_player.GetDeceleration(), ForceMode.Force);
    }

    void Cast_performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Cast " + context.phase);
            //CAST A SPELL
        }
    }
}
