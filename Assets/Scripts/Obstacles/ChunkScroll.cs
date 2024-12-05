using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    //Negative for scrolling down
    public float ScrollSpeed = 3f;
    
    public GameObject Chunk;
    public Transform spawnPoint;
    
    private bool spawned = false;
    
    void Update()
    {
        transform.Translate(Vector2.up * ScrollSpeed * Time.deltaTime);
        //Checks if this chunk has not yet spawned a chunk
        if (transform.position.y > -0.1f && !spawned)
        {
            Instantiate(Chunk, spawnPoint.position, Quaternion.identity);
            spawned = true;
        }
    }
}
//ADD Chunk should be despawned after set time in when instantiated