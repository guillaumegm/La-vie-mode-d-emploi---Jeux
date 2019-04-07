using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string Name;
    public Room itemsRoom;
    public ToolTip toolTip;

	void Start () {
       
    }

    private void OnMouseEnter()
    {
        Debug.Log("OnMouseEnter est activé");
        toolTip.show();
        toolTip.setPosition(this);
    }

    private void OnMouseExit()
    {
        toolTip.hide();
    }

    /*private void OnMouseUp()
    {
        Debug.Log("[Item] Input.mousePosition.X = " + Input.mousePosition.x);
        Debug.Log("[Item] Input.mousePosition.Y = " + Input.mousePosition.y);
        Debug.Log("[Item] this.transform.position.X = " + this.transform.position.x);
        Debug.Log("[Item] this.transform.position.Y = " + this.transform.position.y);
        Debug.Log("------------------");
        Debug.Log("[Item] cam.WorldToScreenPoint(this.transform.position).X = " + cam.WorldToScreenPoint(this.transform.position).x);
        Debug.Log("[Item] cam.WorldToScreenPoint(this.transform.position).Y = " + cam.WorldToScreenPoint(this.transform.position).y);
    }*/

    void Update () {
		
	}
}
