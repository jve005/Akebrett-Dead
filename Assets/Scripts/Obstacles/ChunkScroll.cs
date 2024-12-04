using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    public float ScrollSpeed = 5f;


    void Update()
    {
        transform.Translate(Vector2.down * ScrollSpeed * Time.deltaTime);
    }
}
//Chunk should be despawned after set time in when instantiated