using UnityEngine;
using System.Collections;

public class Turd : MonoBehaviour
{

    public int turdSize = 0;
    // Use this for initialization
    void Awake()
    {
		Debug.Log ("Creating turds.");
		int rand = (int)Random.Range (8,20);
		for(int x=0; x < rand; x++)
		{
        GameObject turd = (GameObject)Instantiate(Resources.Load("turd"));
			turd.name = "turd";
        	turd.transform.position = new Vector3(Random.Range (1,21), 0.187F, Random.Range (1,21));
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}