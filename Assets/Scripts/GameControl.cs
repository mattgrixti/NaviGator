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

        PlayerData data = new PlayerData(PlayerHealth, PlayerLevel, PlayerScore);
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
}

[Serializable]
class PlayerData
{
    public int health;
    public int level;
    public int score;
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