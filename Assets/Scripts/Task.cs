using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task {

    private int hour;
    private string anEvent;
    private Item itemToReach;

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

    public Item ItemToReach
    {
        get
        {
            return itemToReach;
        }

        set
        {
            itemToReach = value;
        }
    }

    public Task(int hour, string anEvent, Item itemToReach)
    {
        Hour = hour;
        AnEvent = anEvent;
        ItemToReach = itemToReach;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
