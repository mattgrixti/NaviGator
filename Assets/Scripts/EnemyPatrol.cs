using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;
    public float timeToTurn;
    private float runningTimer;
	// Use this for initialization
	void Start () {
        runningTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        runningTimer += Time.deltaTime;
        if (runningTimer >= (float) timeToTurn)
        {
            moveRight = !moveRight;
            runningTimer = 0;
        }
        moveEnemy();
    }

    private void moveEnemy()
    {
        if (moveRight)
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }


}
