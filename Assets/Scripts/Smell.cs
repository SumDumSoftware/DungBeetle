using UnityEngine;
using System.Collections;

public class Smell : MonoBehaviour {
	float stinkVelocity = 300f;
	float turn = 20f;
	Rigidbody stinkSmell = new Rigidbody();
	ParticleSystem scent = new ParticleSystem ();
	//GameObject turd = GameObject.FindGameObjectsWithTag ("turd");
	public Transform target;
		// Use this for initialization
	void Start () {
		stinkSmell = transform.GetComponent<Rigidbody>();
		Sniff ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Sniff()
	{
		float distance = Mathf.Infinity;
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("playerbeetle"))
		{
			float diff = (go.transform.position - transform.position).sqrMagnitude;

			if(diff < distance)
			{
				distance = diff;
				target = go.transform;

			}

		}
	}


	void FixedUpdate()
	{
		if (target == null | stinkSmell == null) {
						stinkSmell.velocity = transform.forward * stinkVelocity;

						UnityEngine.Quaternion targetRotation = Quaternion.LookRotation (target.position - transform.position);
						stinkSmell.MoveRotation (Quaternion.RotateTowards (transform.rotation, targetRotation, turn));
				}
	}
}
