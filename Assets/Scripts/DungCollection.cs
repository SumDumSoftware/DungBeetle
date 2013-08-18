using UnityEngine;
using System.Collections;

public class DungCollection : MonoBehaviour {
	
	public AudioClip collectSound;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//play a sound for turd pickup at the point of the player and then increase size of dungball
	void TurdPickup(){
		AudioSource.PlayClipAtPoint (collectSound, transform.position);
		//increase size of existing dungball
	}
	
	//need to create a function to check if there is a dungball, if not, instantiate one on FPC when picking up dung first time
}
