using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public string scenepath;
    
    public Animator animator;
    
    //Time to wait before you're allowed to click out
    public float waitTime = 5f;

    void LoadNextScene()
    {
        SceneManager.LoadScene(scenepath);
    }

    void Update()
    {
        if (waitTime < Time.timeSinceLevelLoad)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current != null)
            {
                animator.Play("PlayAnimation");
                Invoke("LoadNextScene", 2f);
            }
        }
    }
}
