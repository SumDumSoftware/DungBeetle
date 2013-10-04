using UnityEngine;
using System.Collections;

public class DungCollection : MonoBehaviour {
	
	public AudioClip collectSound;	
	
	void OnCollisionEnter(Collision theCollision){
 		if(theCollision.gameObject.name.Contains("turd")){
  			Debug.Log("Hit the floor");
			TurdPickup();
 		}
 	}
	
	//play a sound for turd pickup at the point of the player and then increase size of dungball
	void TurdPickup(){
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		GameObject pt = GameObject.Find("PlayerTurd");	
		if(GameObject.Find("PlayerTurd") == null)
		{
			pt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			pt.transform.position = transform.position;
			pt.name = "PlayerTurd";
		}
		
		//increase size of existing dungball
	}
	
	//need to create a function to check if there is a dungball, if not, instantiate one on FPC when picking up dung first time
}
