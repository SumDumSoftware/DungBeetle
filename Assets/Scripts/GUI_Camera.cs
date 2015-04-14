using UnityEngine;
using System.Collections;

public class GUI_Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Camera>().enabled = false;
		GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GameObject pt = GameObject.Find("PlayerTurd");	
		GameObject ot = GameObject.Find("OptimalTurd");
		if(pt != null)
		{
			if(pt.transform.localScale.x < ot.transform.localScale.x)//If attained optimal Turd size, don't render
			{
			if (Event.current.type == EventType.Repaint)
    		GetComponent<Camera>().Render(); // We want it drawing NOW
			}
		}
	}
}
