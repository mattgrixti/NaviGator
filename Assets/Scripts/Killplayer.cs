using UnityEngine;
using System.Collections;

public class Killplayer : MonoBehaviour {

    public LevelManeger levelManager;
	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManeger>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        Debug.Log("Contact with Player");
        if (other.name == "Navi")
        {
            
        }
    }
}
