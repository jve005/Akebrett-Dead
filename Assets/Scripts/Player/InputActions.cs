using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    public float speed;

    private void Update()
    {
        speed = _inputSystem.Player.Move.ReadValue<Vector2>().x;
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystem.Enable(); }

    private void OnDisable() { _inputSystem.Disable(); }
}
