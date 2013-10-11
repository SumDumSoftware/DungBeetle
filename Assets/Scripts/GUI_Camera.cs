using UnityEngine;
using System.Collections;

public class GUI_Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		camera.enabled = false;
		camera.clearFlags = CameraClearFlags.Depth;
	}
	
	// Update is called once per frame
	void OnGUI () {
		GameObject pt = GameObject.Find("PlayerTurd");	
		if(pt != null)
		{
		if (Event.current.type == EventType.Repaint)
    		camera.Render(); // We want it drawing NOW
		}
	}
}
