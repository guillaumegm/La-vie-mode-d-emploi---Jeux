using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public string roomName;
    //public int roomX;
    //public int roomY;
    public Place roomsPlace;
    /*public bool toTop;
    public bool ToBottom;
    public bool ToLeft;
    public bool ToRight;*/

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

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
