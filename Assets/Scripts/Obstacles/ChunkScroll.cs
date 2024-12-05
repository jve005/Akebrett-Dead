using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    //Make negative for scrolling down
    public float ScrollSpeed = 3f;
    
    void Update()
    {
        transform.Translate(Vector2.up * ScrollSpeed * Time.deltaTime);
    }

}