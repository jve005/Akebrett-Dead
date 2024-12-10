using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CheckForInput : MonoBehaviour
{
    private InputActions _input;
    public string scenepath;

    void Start()
    {
        _input = GetComponent<InputActions>();
    }

    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current != null)
        {
            SceneManager.LoadScene(scenepath);
        }
    }
}
