using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Image HeartUI;
    public int HP;
	public int score;

   void Update ()
    {
        HeartUI.sprite = heartSprite[HP];

    }
	
	public addToScore (int scoreToADD)
	{
		score+scoreToADD;
	}
}

