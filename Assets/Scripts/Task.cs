using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task {

    private int hour;
    private string anEvent;

    public int Hour
    {
        get
        {
            return hour;
        }

        set
        {
            hour = value;
        }
    }

    public string AnEvent
    {
        get
        {
            return anEvent;
        }

        set
        {
            anEvent = value;
        }
    }

    public Task(int hour, string anEvent)
    {
        Hour = hour;
        AnEvent = anEvent;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
