using UnityEngine;
using System.Collections;

public class Pile {

	
	public float rotationSpeed = 100.0f;
	public GameObject currentTurdSize;
	
	// Update is called once per frame
	void Update () {
	
		//rotate the turd
		//transform.Rotate (new Vector3(rotationSpeed*Time.deltaTime, 0, 0));
	}
	
	//collision detection of powercell
	//void OnTriggerEnter(Collider col){
		//if(col.gameObject.tag == "Player"){
			//col.gameObject.SendMessage ("TurdPickup");
						
			//Destroy (gameObject);
		//}
	//}
}
