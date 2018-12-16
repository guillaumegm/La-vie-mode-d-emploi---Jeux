using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public string nameChar;
    public string surnameChar;
    public int ageChar;
    public string descriptionChar;
    public float speed;
    public GameObject testPorte;
    private Agenda agendaChar;
    private int agendaCount;
    private Task nextTask;
    private Task currentTask;
    private Room currentLocation;

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

    public Room CurrentLocation
    {
        get
        {
            return currentLocation;
        }

        set
        {
            currentLocation = value;
        }
    }

    public int AgendaCount
    {
        get
        {
            return agendaCount;
        }

        set
        {
            agendaCount = value;
        }
    }


    // Use this for initialization
    void Start() {
        Debug.Log("c'est part pour le char !!");
        this.Subscribe();
        AgendaChar = gameObject.AddComponent<Agenda>();
        FillAgendaChar();
        AgendaCount = 0;
        NextTask = AgendaChar.AgendaTasks[AgendaCount];
        MoveTo(testPorte);
    }

    // Update is called once per frame
    void Update() {

    }

    void Subscribe()
    {
        Singleton<Clock>.Instance.OneHour += new Clock.ClockHandler(NewHour);
    }

    void NewHour(Clock c, EventArgs e){
        if(NextTask.Hour == Singleton<Clock>.Instance.GameTimeHour)
        {
            CurrentTask = NextTask;
            if(CurrentTask.AnEvent == "travail")
            {
                GoToWork();
            }

            if ((AgendaCount+1) != AgendaChar.AgendaTasks.Count)
            {
                AgendaCount++;
            }
            else
            {
                AgendaCount = 0;
            }
            NextTask = AgendaChar.AgendaTasks[AgendaCount];
        }
    }


    Boolean InTheRoom(Room roomStart, Room roomEnd)
    {
        if (roomStart == roomEnd)
        {
            Debug.Log("Je suis dans la bonne pièce");
            return true;
        }
        else if (roomStart.roomsPlace == roomEnd.roomsPlace)
         {
             Debug.Log("Je suis dans le bon appart");
             return GoToTheRoom(roomStart, roomEnd);
         }
         else if (roomStart.roomsPlace.placesBuilding == roomEnd.roomsPlace.placesBuilding)
         {
            Debug.Log("Je suis dans le bon batiment");
            MoveTo(roomStart.roomsPlace.exit);
            return GoToThePlace(roomStart, roomEnd);
        }
        else return false;
    }


    void MoveTo(GameObject destination)
    {
        Debug.Log("Début Move to");
        while (Math.Abs(this.transform.position.x - destination.transform.position.x) > 1)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, step);
        }
        Debug.Log("Fin Move to");
    }

    Boolean GoToTheRoom(Room roomStart, Room roomEnd)
    {
        
        return false;
    }

    Boolean GoToThePlace(Room roomStart, Room roomEnd)
    {
        return false;
    }

    void GoToWork()
    {
        Debug.Log("Je vais au travail");
    }

    void Eat()
    {
        Debug.Log("Je mange");
    }

    void FillAgendaChar()
    {
        AgendaChar.addTask(2, "petit déj");
        AgendaChar.addTask(3, "travail");
        AgendaChar.addTask(4, "diner");
        AgendaChar.addTask(5, "télé");
        AgendaChar.addTask(6, "dormir");
    }
}
