using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    private bool spawnedNextChunk = false;

    //chunkHeight = 10.8 * number of backgrounds
    public float chunkHeight = 10.8f;

    public int[] starts = new int[3];
    public int[] ends = new int[3];
    
    public List<GameObject> chunkList = new List<GameObject>();

    //Finds a chunk which can merge together with the current one without causing an unstoppable loss
    private static GameObject FindChunk(int[] ends, List<GameObject> chunkList)
    {
        //Pick a random chunk from among the list of chunks
        var chunkNumber = Random.Range(0, chunkList.Count);
        
        //Find the start list numbers from the picked chunk
        var starts = chunkList[chunkNumber].GetComponent<ChunkSpawn>().starts;
        var mergable = false;
        var i = 0;
        while (i < ends.Length)
        {
            if (ends[i] == 0 && starts[i] == 0) { mergable = true; break; }
            i++;
        }
        //Can this and the next chunk merge?
        if (mergable)
        {
            return chunkList[chunkNumber];
        }
        //Otherwise redo the function
        return FindChunk(ends, chunkList);
    }
    
    void FixedUpdate()
    {
        //Check if this chunk has not yet spawned a chunk
        if (transform.position.y > 0f && !spawnedNextChunk)
        {
            var nextChunk = FindChunk(starts, chunkList);
            var spawnPoint = transform.position + new Vector3(0, -chunkHeight, 0);
            Instantiate(nextChunk, spawnPoint, Quaternion.identity);
            //Destroy this chunk in 5 seconds
            Destroy(gameObject, 5f);
            spawnedNextChunk = true;
        }
    }
}