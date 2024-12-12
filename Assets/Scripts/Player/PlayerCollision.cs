using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject playerSprite;
    public GameObject shadow;
    public Vector3 shadowPosition;

    private bool airborne = false;
    private float jumpLength = 1.5f;
    private float jumpTime = 0f;
    private Vector3 playerScaleChange = new Vector3(0.02f, 0.02f, 0.02f);
    private Vector3 shadowmoveChange = new Vector3(0, -0.1f, 0);


    void Start()
    {
        playerScaleChange = playerScaleChange / jumpLength;
        shadowmoveChange = shadowmoveChange / jumpLength;
    }
    
    void Update()
    {
        if (airborne)
        {
            if (jumpTime < jumpLength / 2)
            {
                playerSprite.transform.localScale += playerScaleChange;
                shadow.transform.position += shadowmoveChange;
            }
            else
            {
                playerSprite.transform.localScale -= playerScaleChange;
                shadow.transform.position -= shadowmoveChange;
            }

            if (jumpTime > jumpLength)
            {
                airborne = false;
                playerSprite.transform.localScale = new Vector3(1, 1, 1);
                shadow.transform.localPosition = shadowPosition;
            }
            jumpTime += Time.deltaTime;
        }
    }

    //All Obstacles should be triggers.
    void OnTriggerStay2D(Collider2D collision)
    {
        //Player does not collide with obstacles whilst airborne
        if (!airborne)
        {
            print("Player collision");
            //Rocks, Trees, other children
            //For now it sends you to DeathScreen immediately, it needs to wait for animation
            if (collision.gameObject.tag == "Death")
            {
                //Add death animation
                print("Lose");
                SceneManager.LoadScene("DeathScreen");
            }

            if (collision.gameObject.tag == "Ramp")
            {
                print("Ramp");
                jumpTime = 0f;
                airborne = true;
            }
            
            //Only used for the ending ramp
            if (collision.gameObject.tag == "EndRamp")
            {
                print("EndRamp");
                jumpLength = 3.5f;
                jumpTime = 0f;
                airborne = true;
            }

            //Collider after the big ramp
            if (collision.gameObject.tag == "Win")
            {
                print("Win");
                SceneManager.LoadScene("WinScreen");
            }
    }
}
}
