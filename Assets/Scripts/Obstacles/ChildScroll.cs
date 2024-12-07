using UnityEngine;

public class ChildScroll : MonoBehaviour
{
    public float ScrollSpeed = 1f;
    void Update()
    {
        transform.Translate(Vector2.down * ScrollSpeed * Time.deltaTime);
    }
}
