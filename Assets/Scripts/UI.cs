using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Image HeartUI;
    public Text PointsUI;
    public Text LevelUI;
    public int HP;
    public int Points;
    public int Level;
    public float ScoreTimer;
    public float ScoreTimerTrigger;
    public float ScoreMultiplier;
    private string levelPrefix = "Level: ";

    void start()
    {
    }
   void Update ()
    {
        HeartUI.sprite = heartSprite[HP];
        PointsUI.text = Points.ToString();
        LevelUI.text = levelPrefix + Level.ToString();
        GameControl.control.PlayerHealth = HP;
        GameControl.control.PlayerScore = Points;
        GameControl.control.PlayerLevel = Level;
        if (GameControl.control.TimeBasedScore == true)
        {
            GameControl.control.ScoreTimer = ScoreTimer;
            GameControl.control.ScoreTimerTrigger = ScoreTimerTrigger;
            GameControl.control.ScoreMultiplier = ScoreMultiplier;
            getScoreTimed();
        }
        
    }

    public void save_onClick()
    {
        GameControl.control.Save();
    }
    public void load_onClick()
    {
        
        GameControl.control.Load();
        HP = GameControl.control.PlayerHealth;
        Points = GameControl.control.PlayerScore;
        Level = GameControl.control.PlayerLevel;
        if (GameControl.control.TimeBasedScore == true)
        {
            ScoreMultiplier = GameControl.control.ScoreMultiplier;
            ScoreTimer = GameControl.control.ScoreTimer;
            ScoreTimerTrigger = GameControl.control.ScoreTimerTrigger;
        }
    }

    public void getScoreTimed()
    {
        
        if (ScoreTimerTrigger <= 0)
        {
            ScoreTimer -=  Time.deltaTime;
            PointsUI.text = ((int) (ScoreTimer * ScoreMultiplier)).ToString();
            Points = (int) (ScoreTimer * ScoreMultiplier);
        }
        else
        {
            ScoreTimerTrigger -= Time.deltaTime;
            PointsUI.text = ((int)(ScoreTimer * ScoreMultiplier)).ToString();
            Points = (int)(ScoreTimer * ScoreMultiplier);
        }
    }
}

