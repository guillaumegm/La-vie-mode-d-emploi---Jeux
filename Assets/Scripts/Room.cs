using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public string roomName;
    public Place roomsPlace;

    public string RoomName
    {
        get
        {
            return roomName;
        }

        set
        {
            roomName = value;
        }
    }

    void Start () {
       
	}
	
	void Update () {
		
	}
}
