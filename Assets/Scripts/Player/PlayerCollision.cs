using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSprite;
    public GameObject shadow;
    public GameObject handle;
    public Vector3 shadowPosition;
    public Animator playerAnimator;
    public GameObject variableContainer;
    
    public AudioSource _audioSource;
    public AudioClip deathSound;

    private bool airborne = false;
    private float jumpLength = 1.5f;
    private float jumpTime = 0f;
    private Vector3 playerScaleChange = new Vector3(0.02f, 0.02f, 0.02f);
    private Vector3 shadowmoveChange = new Vector3(0, -0.1f, 0);


    void Die()
    {
        SceneManager.LoadScene("DeathScreen");
    }
    
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
            if (collision.gameObject.tag == "Death")
            {
                print("Lose");
                playerAnimator.SetBool("IsAlive", false);
                variableContainer.GetComponent<SpawnVariables>().isScrolling = false;
                Destroy(handle);
                Destroy(shadow);
                Destroy(collision);
                _audioSource.PlayOneShot(deathSound);
                _audioSource.volume = 1f;
                Invoke("Die", 0.6f);
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
