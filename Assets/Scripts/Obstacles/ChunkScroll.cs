using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    public float ScrollSpeed = 5f;
    
    public GameObject Chunk;
    public Transform spawnPoint;
    
    //Checks if this chunk spawned the next chunk?
    private bool spawned = false;
    
    void Update()
    {
        transform.Translate(Vector2.down * ScrollSpeed * Time.deltaTime);
        if (transform.position.y > 0 && !spawned)
        {
            Instantiate(Chunk, spawnPoint.position, Quaternion.identity);
            spawned = true;
        }
    }
}
//Chunk should be despawned after set time in when instantiated