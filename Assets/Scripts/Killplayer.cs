using UnityEngine;
using System.Collections;

public class Killplayer : MonoBehaviour {

    public LevelManeger levelManager;
    public GameObject enemy;
    private GameObject player;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManeger>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //to be deleted. Replaced with HurtEnemyOnContact script
        //if (other.name == "Navi")
        //{
        //    Player playerData = player.GetComponent<Player>();
        //    if (playerData.grounded == false)
        //    {
        //        Destroy(this.gameObject);
        //        GameObject go = GameObject.Find("mainObject");
        //        UI ui = go.GetComponent<UI>();
        //        GameControl.control.AddPoint();
        //    }
        //}
    }
    
}
