using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton<Clock> {

    private float startTimeSecond;
    private int gameTimeHour;

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

    void Start () {
        StartTimeSecond = 0;
        gameTimeHour = 0;
    }
	
	void Update () {
        if (Time.time - StartTimeSecond >= 1f)
        {
            StartTimeSecond = StartTimeSecond + 1; ;
            Debug.Log("Start time second : " + StartTimeSecond);
            if (StartTimeSecond % 3 == 0)
            {
                GameTimeHour++;
                Debug.Log("Game time hour : " + GameTimeHour);
                if (OneHour != null)
                {
                        OneHour(this, e);
                }
            }
        }
	}
}
