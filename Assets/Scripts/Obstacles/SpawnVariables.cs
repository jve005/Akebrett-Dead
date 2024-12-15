using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVariables : MonoBehaviour
{
    [Header("Chunk Spawns")]
    //Starting chunks start in chunkList
    public List<GameObject> chunkList = new List<GameObject>();
    public List<GameObject> intermediate = new List<GameObject>();
    public List<GameObject> hard = new List<GameObject>();
    public List<GameObject> End = new List<GameObject>();
    private bool intermediateAdded = false;
    private bool hardAdded = false;
    private bool endAdded = false;
    
    public bool isScrolling = true;
    
    public float scrollSpeed;

    public static float ToSingle(double value)
    {
        return (float)value;
    }
    
    private void FixedUpdate()
    {
        //It takes about 12 secs to finish Tutorial Chunk
        
        if (Time.timeSinceLevelLoad > 50f && !intermediateAdded)
        {
            chunkList.AddRange(intermediate);
            intermediateAdded = true;
        }
        
        if (Time.timeSinceLevelLoad > 90f && !hardAdded)
        {
            chunkList.AddRange(hard);
            hardAdded = true;
        }

        if (Time.timeSinceLevelLoad > 160f && !endAdded)
        {
            chunkList.AddRange(End);
            endAdded = true;
        }

        //Starts at less than 4, reaches 10 at 125 secs
        if (isScrolling)
        {
            scrollSpeed = 2 * ToSingle(Math.Log(Time.timeSinceLevelLoad, 5)) + 4f;
        }
        else
        {
            scrollSpeed = 0;
        }
    }
}
