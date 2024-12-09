using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private InputActions _input;
    public Rigidbody2D rigidBody2D;
    private Vector2 _direction;
    public float moveSpeed = 5f;
    public Transform left;
    public Transform middle;
    public Transform right;
    public Transform playerSpot;
    [SerializeField] public Transform[] wayPoint;
    private int _wayPointIndex = 1;
    
    void Start()
    {
        _input = GetComponent<InputActions>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerSpot == null) return;
        _direction = playerSpot.position - transform.position;
        if (transform.position.x > playerSpot.position.x)
        {
            transform.localScale = transform.position.x > playerSpot.position.x ? 
                new Vector2(1, 1) : new Vector2(-1, 1);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame && _wayPointIndex != 0)
        {
            _wayPointIndex--;
            playerSpot = wayPoint[_wayPointIndex];
        }

        if (Keyboard.current.dKey.wasPressedThisFrame && _wayPointIndex != wayPoint.Length - 1)
        {
            _wayPointIndex++;
            playerSpot = wayPoint[_wayPointIndex];
        }
    }

    void FixedUpdate()
    {
        rigidBody2D.linearVelocity = _direction * moveSpeed;
    }
}
