using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVariables : MonoBehaviour
{
    public List<GameObject> chunkList = new List<GameObject>();
    
    public List<GameObject> intermediate = new List<GameObject>();
    private bool intermediateAdded = false;
    
    public List<GameObject> End = new List<GameObject>();
    private bool endAdded = false;

    private void FixedUpdate()
    {
        if (Time.time > 25f && !intermediateAdded)
        {
            chunkList.AddRange(intermediate);
            intermediateAdded = true;
        }

        if (Time.time > 120f && !endAdded)
        {
            chunkList.AddRange(End);
            endAdded = true;
        }
    }
}
