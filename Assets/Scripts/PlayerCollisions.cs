using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {
	
	GameObject currentDoor;
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		if(Physics.Raycast (transform.position, transform.forward, out hit, 3)){
		if(hit.collider.gameObject.tag=="playerDoor"){
				currentDoor = hit.collider.gameObject;
				currentDoor.SendMessage ("DoorCheck");
		}
	}
		
	//check if door is closed and if the player collides with it, open the door/play a sound
//	void OnControllerColliderHit(ControllerColliderHit hit){
//	if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false){
//			currentDoor = hit.gameObject;
//			Door (doorOpenSound, true, "dooropen", currentDoor);
//		}
//	}
//	void Door(AudioClip aClip, bool openCheck, string animName, GameObject thisDoor){
//		thisDoor.audio.PlayOneShot(aClip);
//		doorIsOpen = openCheck;
//		thisDoor.transform.parent.animation.Play(animName);
//	}
}
}