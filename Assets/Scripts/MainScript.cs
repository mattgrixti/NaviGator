using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
    public GameObject pauseUI;
    public GameObject mainMenuUI;
	// Use this for initialization
	void Start () {
        pauseUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
    }

 
    public void quit_onClick()
    {
        Application.Quit();
    }
}
