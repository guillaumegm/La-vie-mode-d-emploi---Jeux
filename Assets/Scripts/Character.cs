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
    public Room currentRoom;

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

    void Start() {
        Debug.Log("c'est part pour le char !!");
        this.Subscribe();
        AgendaChar = gameObject.AddComponent<Agenda>();
        TempFillAgendaChar();
        AgendaCount = 0;
        NextTask = AgendaChar.AgendaTasks[AgendaCount];
        
    }

    void Update() {
        
    }

    void Subscribe()
    {
        Singleton<Clock>.Instance.OneHour += new Clock.ClockHandler(NewHour);
    }

    void NewHour(Clock c, EventArgs e)
    {
        if (NextTask.Hour == Singleton<Clock>.Instance.GameTimeHour)
        {
            CurrentTask = NextTask;
            if (CurrentTask.AnEvent == "travail")
            {
                Debug.Log("[Character.NewHour]On va lancer le GoTo pour le travail ");
                StartCoroutine(GoTo(this.currentRoom, CurrentTask.ItemToReach.itemsRoom, CurrentTask.ItemToReach));
            }

            if ((AgendaCount + 1) != AgendaChar.AgendaTasks.Count)
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

    IEnumerator GoTo(Room roomStart, Room roomEnd, Item itemToReach)
    {
        if (roomStart != roomEnd)
        {
            Debug.Log("[GoTo] Je ne suis pas dans la bonne pièce");
            if (roomStart.roomsPlace != roomEnd.roomsPlace)
            {
                Debug.Log("[GoTo] Je ne suis pas dans le bon appart");
                yield return MoveTo(roomStart.roomsPlace.exit);

                if (roomStart.roomsPlace.floor != roomEnd.roomsPlace.floor)
                {
                    Debug.Log("[GoTo] Je ne suis pas au bon étage");
                    yield return MoveTo(roomStart.roomsPlace.floor.elevatorShaft.exit);
                    yield return MoveToByElevator(roomEnd.roomsPlace.floor.elevatorShaft.exit);
                }
                Debug.Log("[GoTo] Je me dirige vers l'appartement");
                yield return MoveTo(roomEnd.roomsPlace.exit);
            }
            yield return MoveTo(itemToReach);
        }
        
    }

    //Control horizontal moves
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

    //Control vertical moves
    //Probably to merge with MoveTo as soon as possible
    IEnumerator MoveToByElevator(Item destination)
    {
        Debug.Log("Début Move to Elevator");
        float step = speed * Time.deltaTime;
        while (Math.Abs(this.transform.position.y - destination.transform.position.y) > 0.01)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, step);
            yield return null;
        }

        Debug.Log("Fin Move to Elevator");
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
