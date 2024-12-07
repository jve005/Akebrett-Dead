using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject playerSprite;
    public GameObject shadow;
    public Vector3 shadowPosition;

    public bool airborne = false;
    private float jumpLength = 2f;
    private float jumpTime = 0f;
    private Vector3 playerScaleChange = new Vector3(0.03f, 0.03f, 0.03f);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Player does not collide with obstacles whilst airborne
        if (!airborne)
        {
            print("Player collision");
            //Rocks, Trees, other children
            if (collision.gameObject.tag == "Death")
            {
                print("Lose");
                //*Go to Lose Screen*
            }

            if (collision.gameObject.tag == "Ramp")
            {
                print("Ramp");
                jumpTime = 0f;
                airborne = true;
            }

            //Collider after the big ramp
            if (collision.gameObject.tag == "Win")
            {
                print("Win");
                //*Go to Win Screen*
            }
    }
}
}
