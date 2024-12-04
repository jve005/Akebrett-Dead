using System;
using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;
    public float Position;


    private void Update()
    {
        Position = _inputSystem.Player.Move.ReadValue<Vector2>().x;
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystem.Enable(); }

    private void OnDisable() { _inputSystem.Disable(); }
}
