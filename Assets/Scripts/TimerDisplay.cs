using UnityEngine;
using System.Collections;

public class TimerDisplay : MonoBehaviour {

    //set up parameters

    private int time;

    //the header just separtes the variables in the inspector
    [Header("Timer")]
    public int X = 10;
    public int Y = 10;
    public int width = 100;
    public int height = 20;
    public GUIStyle style;

    [Header("Score")]
    public int score;
    

    void OnGUI()
    {
        //draws to the screen
        GUI.Label(new Rect(X, Y, width, height), "Time left: "+time, style);
    }
	
	// Update is called once per frame
	void Update () {
        //finds the time left in the game once per frame
        time = (int)GameObject.Find("GM").GetComponent<GameManager>().timeLeft;
	}
}
