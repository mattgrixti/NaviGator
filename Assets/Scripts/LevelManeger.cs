using UnityEngine;
using System.Collections;

public class LevelManeger : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Player player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RespawnPlayer()
    {
        Debug.Log("Player Respawed");
        player.transform.position = currentCheckpoint.transform.position;
    }
}
