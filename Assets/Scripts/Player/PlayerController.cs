using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputActions _input;
    private Rigidbody2D _rigidBody2D;
    public bool Left;
    public bool Right;
    void Start()
    {
        _input = GetComponent<InputActions>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
    }
}
