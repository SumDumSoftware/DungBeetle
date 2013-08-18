using UnityEngine;
using System.Collections;

public class Turd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float rotationSpeed = 100.0f;
	
	// Update is called once per frame
	void Update () {
	
		//rotate the turd
		transform.Rotate (new Vector3(rotationSpeed*Time.deltaTime, 0, 0));
	}
	
	//collision detection of powercell
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage ("TurdPickup");
			Destroy (gameObject);
		}
	}
}
