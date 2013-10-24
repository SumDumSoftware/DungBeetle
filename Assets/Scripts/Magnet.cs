using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	float speed = 4.0f;
	float increment = 0.1f;
	Vector3 lastPosition = Vector3.zero;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other) {
		
		GameObject pt = GameObject.Find("PlayerTurd");
		GameObject ms = GameObject.Find("Magnetosphere");
		GameObject pb = GameObject.Find("Beetle");
		Debug.Log(other.gameObject.name + " is in trigger.");
        if (other.gameObject.name == pt.name)
		{
			speed = (((transform.position - lastPosition).magnitude)/Time.deltaTime);
			lastPosition = transform.position;
			Debug.Log("Speed is " + speed);
			pt.transform.position = Vector3.Lerp(pt.transform.position, ms.transform.position, increment);
            pt.transform.rotation = Quaternion.Slerp(Quaternion.LookRotation(new Vector3(pb.rigidbody.velocity.x,0,pb.rigidbody.velocity.z)), pt.transform.rotation, speed);
			Debug.Log("Rotation: " + pt.transform.rotation);
		}
        
    }
	
}
