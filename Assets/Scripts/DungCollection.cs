using UnityEngine;
using System.Collections;

public class DungCollection : MonoBehaviour {
	
	public AudioClip collectSound;	
	public float pushPower = 80000.0f;
	public Vector3 forceDirection;
	public float weight = 0.1f;
	
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		
		if(hit.gameObject.name.Contains("turd"))
		{
			Debug.Log ("The gameobject " + hit.gameObject.name + " was hit.");
        	TurdPickup(hit.gameObject);
		}
		else
		{
			if(hit.gameObject.name == "PlayerTurd")
			{
			Rigidbody body = hit.collider.attachedRigidbody;
 
			// no rigidbody
			if (body == null || body.isKinematic) { 
			return; 
			}
			forceDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

			// Apply the push
			body.velocity = forceDirection * (pushPower/(body.mass/2));
				
			}
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collider: " + GetComponent<Collider>().name);
		
		Debug.Log("GameObject Collided with: " + collision.gameObject.name);
		if(collision.gameObject.name.Contains("PlayerTurd"))
		{
			GameObject pt = GameObject.Find("PlayerTurd");
			GameObject ms = GameObject.Find("Magnetosphere");
			
			DestroyObject(GetComponent<Collider>().gameObject);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			pt.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
			pt.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
			pt.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
			pt.GetComponent<Rigidbody>().angularDrag += 4f;
			ms.transform.localPosition += Vector3.forward/3;
			ms.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
			
			//pt.rigidbody.mass += 0.5f;
			ScoreManager.playerScore += 100;
		}
	}
	
	//play a sound for turd pickup at the point of the player and then increase size of dungball
	void TurdPickup(GameObject turd){
		Material newMat = Resources.Load("PebblyTurd", typeof(Material)) as Material;
		GameObject pt = GameObject.Find("PlayerTurd");	
		GameObject pb = GameObject.Find("playerbeetle");
		if(pt == null)
		{
			
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			pt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			pt.name = "PlayerTurd";
			Rigidbody rb = pt.AddComponent(typeof(Rigidbody)) as Rigidbody;
			rb.drag = .95f;
			rb.angularDrag = 80.0f;
			rb.mass = 1.0f;
			pt.GetComponent<Renderer>().material.color = new Color32(112,88,22,0);
			pt.GetComponent<Renderer>().material = newMat;
			pt.layer = 9;
			
			pt.transform.localScale = new Vector3(0.15f,0.15f,0.15f);
			
			//Vector3 fwd = transform.TransformDirection(Vector3.forward);
			//pt.transform.position = pb.transform.position + fwd/3;
			//animateTurdBuild(turd);
			pt.transform.position = turd.GetComponent<Rigidbody>().position;
			DestroyObject(turd);
			
			ScoreManager.playerScore += 1000;
		}
		//increase size of existing dungball
	}
	
	void animateTurdBuild(GameObject turd){
		GameObject pb = GameObject.Find("RockMesh");
		Vector3 rememberBeetlePos = pb.GetComponent<Rigidbody>().position;
		
		for(int x=0; x < 10000; x++)
		{
			pb.GetComponent<Rigidbody>().position = Random.onUnitSphere * 10;			
		}
		
	}
	
	//need to create a function to check if there is a dungball, if not, instantiate one on FPC when picking up dung first time
}
