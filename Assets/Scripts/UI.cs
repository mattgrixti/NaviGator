using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    public Sprite[] heartSprite;
    public Image HeartUI;
    public int HP;

   void Update ()
    {
        HeartUI.sprite = heartSprite[HP];

    }
}

