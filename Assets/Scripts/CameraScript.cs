using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private int borderDelta;
    private float camSpeed = 0.03f;

    //private Vector3 rightDirection = Vector3.right;
    //private Vector3 leftDirection = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), 0);

    private Vector2 vectorBetweenMouseAndCenter;


    public int BorderDelta
    {
        get
        {
            return borderDelta;
        }

        set
        {
            borderDelta = value;
        }
    }

    // Use this for initialization
    void Start () {
        BorderDelta = 10;
	}
	
	// Update is called once per frame
	void Update () {

        vectorBetweenMouseAndCenter = new Vector3(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2), 0);
        
		if(Input.mousePosition.x >= Screen.width - BorderDelta || Input.mousePosition.x <= BorderDelta || Input.mousePosition.y >= Screen.height - BorderDelta || Input.mousePosition.y <= BorderDelta)
        {
            this.transform.position += (Vector3)vectorBetweenMouseAndCenter * Time.deltaTime * camSpeed;
        }
        
    }
}
