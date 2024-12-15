using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public string scenepath;
    
    public Animator animator;
    public Animator ritaAnimator;
    
    //Time to wait before you're allowed to click out
    public float waitTime = 5f;

    void LoadNextScene()
    {
        SceneManager.LoadScene(scenepath);
    }

    void PlaySnow()
    {
        animator.Play("PlayAnimation");
    }



    void Update()
    {
        if (waitTime < Time.timeSinceLevelLoad)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current != null)
            {
                ritaAnimator.Play("RitaStartAnimation");
                Invoke("PlaySnow", 1f);
                Invoke("LoadNextScene", 2.15f);
            }
        }
    }
    public void QuitGame()
    {
        print("Exiting game");
        Application.Quit();
    }
}
