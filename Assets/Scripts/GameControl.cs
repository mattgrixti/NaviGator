using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
/*
Holds all the data regarding Player Status (HP, Level, Score etc...)
persists through all scenes and can be called anywhere
*/
public class GameControl : MonoBehaviour
{
    public static GameControl control;
    private int playerHealth;
    private int playerScore;
    private int playerLevel;
    private float scoreTimer;
    private float scoreTimerTrigger;
    private float scoreMultiplier;
    private bool timeBasedScore;

    //this checks to see if game objects exists anywhere...
    //if it does delete and if it doenst MAKE THIS the game control
    //singleton ish behavior
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.navi");

        PlayerData data = new PlayerData(PlayerHealth, PlayerLevel, PlayerScore,scoreTimer, scoreTimerTrigger, scoreMultiplier);
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.navi"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.navi",FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            PlayerHealth = data.health;
            PlayerLevel = data.level;
            PlayerScore = data.score;
            ScoreMultiplier = data.ScoreMultiplier;
            ScoreTimerTrigger = data.ScoreTimerTrigger;
            ScoreTimer = data.ScoreTimer;
}
    }


    public int PlayerHealth
    {
        get
        {
            return playerHealth;
        }

        set
        {
            playerHealth = value;
        }
    }

    public int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
        }
    }

    public int PlayerLevel
    {
        get
        {
            return playerLevel;
        }

        set
        {
            playerLevel = value;
        }
    }

    public float ScoreTimer
    {
        get
        {
            return scoreTimer;
        }

        set
        {
            scoreTimer = value;
        }
    }

    public float ScoreTimerTrigger
    {
        get
        {
            return scoreTimerTrigger;
        }

        set
        {
            scoreTimerTrigger = value;
        }
    }

    public float ScoreMultiplier
    {
        get
        {
            return scoreMultiplier;
        }

        set
        {
            scoreMultiplier = value;
        }
    }

    public bool TimeBasedScore
    {
        get
        {
            return timeBasedScore;
        }

        set
        {
            timeBasedScore = value;
        }
    }
}

[Serializable]
class PlayerData
{
    public int health;
    public int level;
    public int score;
    public float ScoreTimer;
    public float ScoreTimerTrigger;
    public float ScoreMultiplier;

    public PlayerData(int health, int level, int score, float ScoreTimer, float ScoreTimerTrigger, float ScoreMultiplier)
    {
        this.health = health;
        this.level = level;
        this.score = score;
        this.ScoreTimer = ScoreTimer;
        this.ScoreTimerTrigger = ScoreTimerTrigger;
        this.ScoreMultiplier = ScoreMultiplier;
    }

    public PlayerData (int health, int level, int score)
    {
        this.health = health;
        this.level = level;
        this.score = score;
    }
    public PlayerData(int health, int level)
    {
        this.health = health;
        this.level = level;
    }
    public PlayerData()
    {
    }
    public PlayerData(int level)
    {
        this.level = level;
    }
}