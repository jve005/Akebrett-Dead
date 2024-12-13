using UnityEngine;

public class ChunkScroll : MonoBehaviour
{
    //Make negative for scrolling down
    //Keep all variables the same on all chunks
    private float scrollSpeed;
    
    private GameObject variableContainer;

    void Start()
    {
        variableContainer = GameObject.Find("VariableContainer");
        
    }
    
    void Update()
    {
        //Check SpawnVariables for speedcalculation
        scrollSpeed = variableContainer.GetComponent<SpawnVariables>().scrollSpeed;
        transform.Translate((Vector2.up * scrollSpeed * Time.deltaTime));
    }
    //Speed should start at around 5 and end at around 10
}