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
			body.velocity = forceDirection * (pushPower/body.mass);
			}
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Collider: " + collider.name);
		
		Debug.Log("GameObject Collided with: " + collision.gameObject.name);
		if(collision.gameObject.name.Contains("PlayerTurd"))
		{
			GameObject pt = GameObject.Find("PlayerTurd");
			
			DestroyObject(collider.gameObject);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			pt.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
			pt.rigidbody.mass += 1.2f;
		}
	}
	
	//play a sound for turd pickup at the point of the player and then increase size of dungball
	void TurdPickup(GameObject turd){
		GameObject pt = GameObject.Find("PlayerTurd");	
		if(pt == null)
		{
			DestroyObject(turd);
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
			pt = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			pt.name = "PlayerTurd";
			Rigidbody rb = pt.AddComponent(typeof(Rigidbody)) as Rigidbody;
			rb.drag = .001f;
			rb.mass = 1.0f;
			pt.renderer.material.color = new Color32(112,88,22,0);
			
			pt.transform.localScale = new Vector3(0.15f,0.15f,0.15f);
			
			pt.transform.position = transform.position;
			pt.transform.position += new Vector3(0f,-0.15f,0.5f);			
		}
		
		
		//increase size of existing dungball
	}
	
	//need to create a function to check if there is a dungball, if not, instantiate one on FPC when picking up dung first time
}
