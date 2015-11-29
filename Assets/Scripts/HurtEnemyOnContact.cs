﻿using UnityEngine;
using System.Collections;

public class HurtEnemyOnContact : MonoBehaviour {

    private Animator animator;

    public float bounceOnEnemy;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            animator = other.GetComponent<Animator>();
            animator.SetBool("isSquished", true);

            rb2d.velocity = new Vector2(rb2d.velocity.x, bounceOnEnemy);
        }

        //Player playerData = GetComponent<Player>();

        //if (other.tag == "Enemy" ) //&& playerData.grounded == false)
        //{
        //    animator = other.GetComponent<Animator>();
        //    animator.SetBool("isSquished", true);

        //    float i = 0;
        //    do
        //    {
        //        i = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //    } while (i != 1);

        //        Destroy(other.gameObject);
        //        GameObject go = GameObject.Find("mainObject");
        //        UI ui = go.GetComponent<UI>();
        //        GameControl.control.AddPoint();
        //}
    }
}
