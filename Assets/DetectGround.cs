using UnityEngine;
using System.Collections;

public class DetectGround : MonoBehaviour {
    GameObject edgeDetector;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Floor")
        {
            Debug.Log("MinionNotOnFloor");
            Vector3 asd = gameObject.transform.position;
            gameObject.transform.position.Set(-1 * asd.x, asd.y, asd.z);
        }
    }
}
