using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVariables : MonoBehaviour
{
    public List<GameObject> chunkList = new List<GameObject>();
    
    public List<GameObject> intermediate = new List<GameObject>();
    private bool intermediateAdded = false;
    
    public List<GameObject> hard = new List<GameObject>();
    private bool hardAdded = false;
    
    public List<GameObject> End = new List<GameObject>();
    private bool endAdded = false;
    
    public float scrollSpeed = 0.1f;

    public static float ToSingle(double value)
    {
        return (float)value;
    }
    
    private void FixedUpdate()
    {
        if (Time.time > 25f && !intermediateAdded)
        {
            chunkList.AddRange(intermediate);
            intermediateAdded = true;
        }
        
        if (Time.time > 90f && !hardAdded)
        {
            chunkList.AddRange(hard);
            hardAdded = true;
        }

        if (Time.time > 180f && !endAdded)
        {
            chunkList.AddRange(End);
            endAdded = true;
        }

        //Starts at less than 4, reaches 10 at 125 secs
        scrollSpeed = 2 * ToSingle(Math.Log(Time.timeSinceLevelLoad, 5)) + 4f;
    }
}
