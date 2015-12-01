using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public LevelManeger levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManeger>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            levelManager.currentCheckpoint = gameObject;
    }
}
