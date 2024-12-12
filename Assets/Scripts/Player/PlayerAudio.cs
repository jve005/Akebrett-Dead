using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private AudioSource _audio;
    private float waitTime;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Mathf.Abs(_rigidbody.linearVelocityX) > 3f && waitTime <= 0f)
        {
            _audio.Play();
            waitTime = 1f;
        }
        else
        {
            //_audio.Pause();
        }
        waitTime -= Time.deltaTime;
    }
}
