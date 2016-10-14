using UnityEngine;
using System.Collections;

public class TimerDisplay : MonoBehaviour {

    //set up parameters

    private float time;
    private float totalTime;
    public static GameObject timerPrefab;

    //the header just separtes the variables in the inspector
    [Header("Timer")]
    static public float X = 10;
    static public float Y = 10;
    
    void Start()
    {

    }


    void OnGUI()
    {
        //draws to the screen
        totalTime = GameObject.Find("GM").GetComponent<GameManager>().totaltime;
        time = GameObject.Find("GM").GetComponent<GameManager>().timeLeft;
        this.GetComponentInChildren<Renderer>().material.SetFloat("_Cutoff", (1 - (time / totalTime)));
    }
	
}

