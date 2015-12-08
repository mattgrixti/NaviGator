using UnityEngine;
using System.Collections;

public class CheckSound : MonoBehaviour {
    public GameObject sound;
	// Use this for initialization
	void Start () {
        Debug.Log("Sound: " + GameControl.control.SoundMute);
	    if (GameControl.control.SoundMute)
        {
            gameObject.SetActive(true);
        }
        else gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
