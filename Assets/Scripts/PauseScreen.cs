using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

    // Use this for initialization
    public GameObject pauseCanvas;
    private bool pauseState = false;
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Pause"))
        {
            pauseState = !pauseState;

            if (pauseState)
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}

    public void resume_onClick()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart_onClick()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void mainMenu_onClick()
    {
        Application.LoadLevel(0);
    }

}
