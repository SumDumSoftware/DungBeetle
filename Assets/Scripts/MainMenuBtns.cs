using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class MainMenuBtns : MonoBehaviour {
	
	public string levelToLoad;
	public Texture2D normalTexture;
	public Texture2D rollOverTexture;
	public AudioClip beep;
	public bool quitButton = false;
	
	// Change menu items to mouse rollover state
	void OnMouseEnter(){
		GetComponent<GUITexture>().texture = rollOverTexture;	
	}
	
	// Change menu items back to rest state
	void OnMouseExit(){
		GetComponent<GUITexture>().texture = normalTexture;
	}
	
	// Sound and load level upon selection of play
	IEnumerator OnMouseUp(){
		GetComponent<AudioSource>().PlayOneShot (beep);	
		yield return new WaitForSeconds(0.7f);
		if (quitButton){
			Application.Quit ();
			Debug.Log ("It just quit...it just freakin' quit!");
		}
		else{
		Application.LoadLevel (levelToLoad);
		}
	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
