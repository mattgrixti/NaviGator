using UnityEngine;
using System.Collections;

public class KillMinion : MonoBehaviour {

    public LevelManeger levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManeger>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2d(EdgeCollider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy Detected");
        }
    }
}
