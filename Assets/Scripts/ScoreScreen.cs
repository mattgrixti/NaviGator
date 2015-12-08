using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {
    public Text score;
    public Text win;
    public GameObject musicWin;
    public GameObject musicLoss;
    private int userScore;
    private int currentScore;
   
    // Use this for initialization
    void Start () {
        
        if (GameControl.control.SoundMute)
        {
            if (GameControl.control.PlayerWin)
            {
                win.text = "You WIN!!!";
                musicWin.SetActive(true);
            }
            else
            {
                win.text = "You Lose :(";
                musicLoss.SetActive(true);
            }
        }
        currentScore = 0;
        userScore = GameControl.control.PlayerScore;
	}
	
	// Update is called once per frame
	void Update () {
        if (currentScore != userScore)
        {
            currentScore += 1;
            score.text = currentScore.ToString();
        }
	}
}
