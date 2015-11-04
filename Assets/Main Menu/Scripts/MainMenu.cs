// Main menu attaches to main camera


using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    //Button 1 X,Y,Width,Height
    public float button1XAxis;
    public float button1YAxis;
    public float button1Width;
    public float button1Height;
    public string button1Text;

    //Button 2 X,Y,Width,Height
    public float button2XAxis;
    public float button2YAxis;
    public float button2Width;
    public float button2Height;
    public string button2Text;

    //Button 3 X,Y,Width,Height
    public float button3XAxis;
    public float button3YAxis;
    public float button3Width;
    public float button3Height;
    public string button3Text;




    //Displays Background
    void OnGUI()
    {
        // x , y , width , height , picture of the background
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);


        //Display Play
        GUI.Button(new Rect(Screen.width * button1XAxis, Screen.height * button1YAxis, Screen.width * button1Width, Screen.height * button1Height), button1Text);

        //Display Option
        GUI.Button(new Rect(Screen.width * button2XAxis, Screen.height * button2YAxis, Screen.width * button2Width, Screen.height * button2Height), button2Text);

        //Display Exit
        GUI.Button(new Rect(Screen.width * button3XAxis, Screen.height * button3YAxis, Screen.width * button3Width, Screen.height * button3Height), button3Text);
    }
}
