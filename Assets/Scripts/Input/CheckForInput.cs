using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CheckForInput : MonoBehaviour
{
    public string scenepath;
    
    //Time to wait before you're allowed to click out
    public float waitTime = 1f;

    void Update()
    {
        if (waitTime < Time.time)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current != null)
            {
                SceneManager.LoadScene(scenepath);
            }
        }
    }
}
