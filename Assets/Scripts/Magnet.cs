using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
	float speed = 4.0f;
	float increment = 0.1f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider other) {
		
		GameObject pt = GameObject.Find("PlayerTurd");
		GameObject pb = GameObject.Find("Magnetosphere");
		Debug.Log(other.gameObject.name + " is in trigger.");
        if (other.gameObject.name == pt.name)
		{
			pt.transform.position = Vector3.Lerp(pt.transform.position, pb.transform.position, increment);
            //other.attachedRigidbody.AddForce(Vector3.up * 10);
		}
        
    }
	
}
