using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private Player thePlayer;
    private Animator playerAnimator;


	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        playerAnimator = thePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        //if (thePlayer.onLadder && Input.GetKey(KeyCode.UpArrow))
        //{
        //    playerAnimator.SetBool("isStair", true);
        //}
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Navi")
        {
            thePlayer.onLadder = true;
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    playerAnimator.SetBool("isStair", true);
            //}
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Navi")
        {
            thePlayer.onLadder = false;
            playerAnimator.SetBool("isStair", false);
        }

    }

}
