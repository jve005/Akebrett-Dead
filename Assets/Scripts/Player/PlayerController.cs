using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Animator _animator;
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audio;
    private Vector2 _direction;
    public float moveSpeed = 5f;
    public Transform playerSpot;
    public float moveDir;
    [SerializeField] public Transform[] wayPoint;
    private int _wayPointIndex = 1;
    
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
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
        _animator.SetFloat("Movement", _direction.x);

        if (moveDir < 0 && _wayPointIndex != 0)
        {
            _audio.Play();
            _wayPointIndex--;
            playerSpot = wayPoint[_wayPointIndex];
        }

        if (moveDir > 0 && _wayPointIndex != wayPoint.Length - 1)
        {
            _audio.Play();
            _wayPointIndex++;
            playerSpot = wayPoint[_wayPointIndex];
        }
        moveDir = GetComponent<InputActions>().moveDir;
    }

    void FixedUpdate()
    {
        _rigidBody2D.linearVelocity = _direction * moveSpeed;
    }
}
