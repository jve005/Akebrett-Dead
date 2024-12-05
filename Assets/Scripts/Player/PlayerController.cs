using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions _input;
    private Rigidbody2D _rigidBody2D;
    public float moveSpeed = 5f;
    public GameObject Left;
    public GameObject Middle;
    public GameObject Right;
    void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        _rigidBody2D.linearVelocityX = _input.speed * moveSpeed;
    }
}
