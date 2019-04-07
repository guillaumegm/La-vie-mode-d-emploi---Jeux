using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton<Clock> {
    
    //Count real seconds spent this game is launched
    private float startTimeSecond;
    //Count hours in the game
    private int gameTimeHour;
    //Modulo value to convert "startTimeSecond" into "gameTimeHour"
    private int secondByHour;

    //For the Singleton
    public EventArgs e = null;
    public delegate void ClockHandler(Clock c, EventArgs e);
    public event ClockHandler OneHour;

    public int GameTimeHour
    {
        get
        {
            return gameTimeHour;
        }

        set
        {
            gameTimeHour = value;
        }
    }

    public float StartTimeSecond
    {
        get
        {
            return startTimeSecond;
        }

        set
        {
            startTimeSecond = value;
        }
    }

    public int SecondByHour
    {
        get
        {
            return secondByHour;
        }

        set
        {
            secondByHour = value;
        }
    }

    void Start () {
        StartTimeSecond = 0;
        GameTimeHour = 0;
        SecondByHour = 3;
    }
	
	void Update () {
        if (Time.time - StartTimeSecond >= 1f)
        {
            StartTimeSecond = StartTimeSecond + 1;
            Debug.Log("Start time second : " + StartTimeSecond);
            if (StartTimeSecond % SecondByHour == 0)
            {
                if (GameTimeHour == 23)
                {
                    GameTimeHour = 0;
                }
                else
                {
                    GameTimeHour++;
                }
                
                Debug.Log("Game time hour : " + GameTimeHour);
                if (OneHour != null)
                {
                        OneHour(this, e);
                }
            }
        }
	}
}
