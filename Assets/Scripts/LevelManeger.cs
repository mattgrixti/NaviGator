using UnityEngine;
using System.Collections;

public class LevelManeger : MonoBehaviour {

    public GameObject currentCheckpoint;
    public GameObject WinCheckpoint;

    private Player player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Boss") == null)
        {
            WinCheckpoint.SetActive(true);
        }
    }
    public void RespawnPlayer()
    {
        player.transform.position = currentCheckpoint.transform.position;
    }
    public void gameOver()
    {

    }
}
