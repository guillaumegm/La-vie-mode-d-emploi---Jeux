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

    public Item tempTargetBreakfast;
    public Item tempTargetWork;
    public Item tempTargetApero;
    public Item tempTargetDiner;
    public Item tempTargetSleep;

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
        TempFillAgendaChar();
        AgendaCount = 0;
        NextTask = AgendaChar.AgendaTasks[AgendaCount];
        
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
                GoTo(this.CurrentLocation, CurrentTask.ItemToReach.itemsRoom);
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


    void GoTo(Room roomStart, Room roomEnd)
    {
        if (roomStart != roomEnd)
        {
            Debug.Log("Je ne suis pas dans la bonne pièce, je sorts");
        
            if (roomStart.roomsPlace != roomEnd.roomsPlace)
            {
                 Debug.Log("Je ne suis pas dans le bon appart");
                StartCoroutine(MoveTo(roomStart.roomsPlace.exit));
                StartCoroutine(MoveTo(roomStart.roomsPlace.exit));
            }
            if (roomStart.roomsPlace.placesBuilding == roomEnd.roomsPlace.placesBuilding)
            {
                Debug.Log("Je suis dans le bon batiment");
                //MoveTo(roomStart.roomsPlace.exit);
                //GoToThePlace(roomStart, roomEnd);
            }
        }
    }


    IEnumerator MoveTo(Item destination)
    {
        Debug.Log("Début Move to");
            float step = speed * Time.deltaTime;
        while (Math.Abs(this.transform.position.x - destination.transform.position.x) > 0.01)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, step);
            yield return null;
        }

        Debug.Log("Fin Move to");
    }

    void TempFillAgendaChar()
    {
        AgendaChar.addTask(1, "petit déj", tempTargetBreakfast);
        AgendaChar.addTask(2, "travail", tempTargetWork);
        AgendaChar.addTask(3, "apéro", tempTargetApero);
        AgendaChar.addTask(4, "diner", tempTargetDiner);
        AgendaChar.addTask(5, "dormir", tempTargetSleep);
    }
}
