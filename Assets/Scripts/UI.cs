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
    private string levelPrefix = "Level: ";

   void Update ()
    {
        HeartUI.sprite = heartSprite[HP];
        PointsUI.text = Points.ToString();
        LevelUI.text = levelPrefix + Level.ToString();
    }
}

