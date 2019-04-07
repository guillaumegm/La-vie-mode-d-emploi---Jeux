using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {

    public Camera cam;

	// Use this for initialization
	void Start () {
        hide();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPosition(Item item)
    {
        Debug.Log("[ToolTip]set Position");
        this.GetComponent<Transform>().position = new Vector2(cam.WorldToScreenPoint(item.transform.position).x, cam.WorldToScreenPoint(item.transform.position).y);
        //this.GetComponent<Text>() = "coucou";
        this.GetComponent<Text>().text = item.Name;
    }

    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }
}
