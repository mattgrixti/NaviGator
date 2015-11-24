using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

    private Player thePlayer;


	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Navi")
        {
            thePlayer.onLadder = true;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Navi")
        {
            thePlayer.onLadder = false;
        }

    }

}
