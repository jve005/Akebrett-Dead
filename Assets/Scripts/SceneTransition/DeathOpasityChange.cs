using UnityEngine;

public class DeathOpasityChange : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private float currentOpacity = 0f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        _spriteRenderer.color = new Color(1f, 1f, 1f, currentOpacity);
        currentOpacity += 0.0005f;
    }
}
