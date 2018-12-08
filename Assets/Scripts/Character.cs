using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private String nameChar;
    private String surnameChar;
    private int ageChar;
    private String descriptionChar;
    private Agenda agendaChar;
    private Task nextTask;
    private Task currentTask;

    public string Name
    {
        get
        {
            return nameChar;
        }

        set
        {
            nameChar = value;
        }
    }

    public string SurnameChar
    {
        get
        {
            return surnameChar;
        }

        set
        {
            surnameChar = value;
        }
    }

    public Task NextTask
    {
        get
        {
            return nextTask;
        }

        set
        {
            nextTask = value;
        }
    }

    public Agenda AgendaChar
    {
        get
        {
            return agendaChar;
        }

        set
        {
            agendaChar = value;
        }
    }

    public Task CurrentTask
    {
        get
        {
            return currentTask;
        }

        set
        {
            currentTask = value;
        }
    }


    // Use this for initialization
    void Start() {
        Debug.Log("Debut Script character");
        this.Subscribe();
        AgendaChar = gameObject.AddComponent<Agenda>();
        FillAgendaChar();
        NextTask = AgendaChar.AgendaTasks[0];
    }

    // Update is called once per frame
    void Update() {

    }

    void Subscribe()
    {
        Singleton<Clock>.Instance.OneHour += new Clock.ClockHandler(NewHour);
    }

    void NewHour(Clock c, EventArgs e){
        Debug.Log("J'ai entendu  ! il est une heure de plus ! Genre " + Singleton<Clock>.Instance.GameTimeHour + "h!");
        if(NextTask.Hour == Singleton<Clock>.Instance.GameTimeHour)
        {
            Debug.Log("Mais oui ! Il est : " + NextTask.Hour + ", c'est l'heure de : " + NextTask.AnEvent);
        }
        }

    void GoToEatBreakfast()
    {
        Debug.Log("Je vais manger mon petit déjeuner");
    }

    void Eat()
    {
        Debug.Log("Je mange");
    }

    void FillAgendaChar()
    {
        AgendaChar.addTask(2, "petit déj");
        AgendaChar.addTask(8, "travail");
        AgendaChar.addTask(19, "diner");
        AgendaChar.addTask(20, "télé");
        AgendaChar.addTask(22, "dormir");
    }
}
