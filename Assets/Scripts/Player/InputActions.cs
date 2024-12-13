using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    public float moveDir;

    private void Update()
    {
        if (_inputSystem.Player.Move.WasPressedThisFrame())
        {
            moveDir = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        }
        else {moveDir = 0;}
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystem.Enable(); }

    private void OnDisable() { _inputSystem.Disable(); }
}
