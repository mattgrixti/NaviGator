using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject optionPanel;
    private bool toogleValue = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void newGame_onClick()
    {
        //Start New Game jump to scene 1
        mainMenu.SetActive(false);
        Application.LoadLevel(1);
    }
    public void options_onClick()
    {
        optionPanel.SetActive(true);
    }
    public void quit_onClick()
    {
        Application.Quit();
    }
    public void OnValueChangedTimeAttackChallenge ()
    {
        if (toogleValue)
        {
            toogleValue = !toogleValue;
            GameControl.control.TimeBasedScore = toogleValue;
        }
        else
        {
            toogleValue = !toogleValue;
            GameControl.control.TimeBasedScore = toogleValue;
        }
    }
    public void back_onClick()
    {
        optionPanel.SetActive(false);
    }
}
