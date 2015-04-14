using UnityEngine;
using System.Collections;

public class CameraDraw : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 GetComponent<Camera>().enabled = false; // We don't want this camera drawing normally
		 GetComponent<Camera>().clearFlags = CameraClearFlags.Depth; // Transparent where no objects
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI ()
	{
		GUILayout.Label("There are 3D objects on top of this!");
		if (Event.current.type == EventType.Repaint)
			GetComponent<Camera>().Render(); // We want it drawing NOW
		GUILayout.Label("There are 3D objects beneath this!");	
	}
}
