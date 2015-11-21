using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject optionPanel;
    public Dropdown dropDownGraphics;
    public Toggle fullScreenGraphics;
    public Toggle sound;
    public AudioSource bgMusic;
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
    public void graphicsChange()
    {
        int resolutionChange = dropDownGraphics.value;
        int width = 1280;
        int height = 960;
        bool isFullScreen;
        switch(resolutionChange)
        {
            case 0:
                width = 1920;
                height = 1080;
                break;

            case 1:
                width = 1600;
                height = 1024;
                break;
            case 2:
                width = 1280;
                height = 960;
                break;
            case 3:
                width = 1024;
                height = 768;
                break;
            case 4:
                width = 800;
                height = 600;
                break;
            default:
                width = 1600;
                height = 1024;
                break;
        }
        isFullScreen = fullScreenGraphics.isOn;
        Screen.SetResolution(width, height, isFullScreen);

    }

    public void OnValueChangeSound()
    {
        if (sound.isOn == false)
        {
            bgMusic.enabled = false;
        }
        else
        {
            bgMusic.enabled = true;
        }
        GameControl.control.SoundMute = sound.isOn;
    }
    
}
