using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVariables : MonoBehaviour
{
    public List<GameObject> chunkList = new List<GameObject>();
    
    public List<GameObject> intermediate = new List<GameObject>();
    private bool intermediateadded = false;

    private void FixedUpdate()
    {
        if (Time.time > 10f && !intermediateadded)
        {
            chunkList.AddRange(intermediate);
            intermediateadded = true;
        }
        print(chunkList[0]);
    }
}
