using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    //Make negative for scrolling down
    //Keep all variables the same on all chunks
    public float ScrollSpeed = 3f;
    public float ScrollAcceleration = 0.2f;
    
    void Update()
    {
        //Move for Startspeed then add accelaration
        transform.Translate((Vector2.up * ScrollSpeed * Time.deltaTime));
        transform.Translate(Vector2.up * ScrollAcceleration * Time.time * Time.deltaTime);
    }

}