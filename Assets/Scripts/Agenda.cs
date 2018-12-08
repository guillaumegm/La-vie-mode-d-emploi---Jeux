using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agenda : MonoBehaviour {

    List<Task> agendaTasks;

    public List<Task> AgendaTasks
    {
        get
        {
            return agendaTasks;
        }

        set
        {
            agendaTasks = value;
        }
    }

    public void addTask(int hour, String anEvent)
    {
        AgendaTasks.Add(new Task(hour, anEvent));
    }
    
	// Use this for initialization
	public Agenda () {
        Debug.Log("début Agenda");
        AgendaTasks = new List<Task>();
        Debug.Log(AgendaTasks.ToString());
        Debug.Log("Fin début Agenda");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
