using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawn : MonoBehaviour
{
    private bool spawnedNextChunk = false;

    //chunkHeight = number of backgrounds
    public float chunkHeight = 3f;
    
    private GameObject VariableContainer;

    public int[] starts = new int[3];
    public int[] ends = new int[3];
    
    private List<GameObject> chunkList = new List<GameObject>();

    void Start()
    {
        VariableContainer = GameObject.Find("VariableContainer");
        chunkList = VariableContainer.GetComponent<SpawnVariables>().chunkList;
        print(chunkList);
    }
    
    //Finds a chunk which can merge together with the current one without causing an unstoppable loss
    private static GameObject FindChunk(int[] ends, List<GameObject> chunkList)
    {
        //Pick a random chunk from among the list of chunks
        var chunkNumber = Random.Range(0, chunkList.Count - 1);
        
        //Find the starts list from the picked chunk
        var starts = chunkList[chunkNumber].GetComponent<ChunkSpawn>().starts;
        var mergable = false;
        var i = 0;
        while (i < ends.Length)
        {
            if (ends[i] == 0 && starts[i] == 0) {mergable = true; break; }
            i++;
        }
        
        //Can this and the next chunk merge?
        if (mergable)
        {
            return chunkList[chunkNumber];
        }
        else
        {
            //Otherwise redo the function
            print(chunkNumber);
            print("Impossible chunk found");
            return FindChunk(ends, chunkList);
        }
    }
    
    void FixedUpdate()
    {
        //Check if this chunk has not yet spawned a chunk
        if (transform.position.y > 0f && !spawnedNextChunk)
        {
            var nextChunkPrefab = FindChunk(ends, chunkList);
            //Each background is 10.8 units tall. Spawns 10.8 * backgrounds below.
            var spawnPoint = transform.position + new Vector3(0, -chunkHeight * 10.8f, 0);
            var chunkGameObject = Instantiate(nextChunkPrefab, spawnPoint, Quaternion.identity);
            chunkGameObject.GetComponent<ChunkSpawn>().VariableContainer = VariableContainer;
            
            //Destroy this chunk in 30 seconds
            Destroy(gameObject, 30f);
            spawnedNextChunk = true;
        }
    }
}
//chillchunk 1 went into chunk 3
//chillchunk 1 went into chunk 1