﻿using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Die()
    {
        Destroy(gameObject);
    }
}