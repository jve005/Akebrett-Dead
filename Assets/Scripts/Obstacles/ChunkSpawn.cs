using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    private bool spawnedNextChunk = false;

    //chunkHeight = 10.8 * number of backgrounds
    public float chunkHeight = 10.8f;
    
    //ADD spawn chunks randomly from a list
    public List<GameObject> chunkList = new List<GameObject>();
    
    void FixedUpdate()
    {
        //Checks if this chunk has not yet spawned a chunk
        if (transform.position.y > 0f && !spawnedNextChunk)
        {
            var chunkNumber = Random.Range(0, chunkList.Count);
            
            var spawnPoint = transform.position + new Vector3(0, -chunkHeight, 0);
            Instantiate(chunkList[chunkNumber], spawnPoint, Quaternion.identity);
            //Destroy this chunk in 5 seconds
            Destroy(gameObject, 5f);
            spawnedNextChunk = true;
        }
    }
}