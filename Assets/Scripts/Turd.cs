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
			float horizontal = Random.Range (1,21);
			float vertical = Random.Range (1,21);
			Vector3 location = new Vector3(horizontal,0, vertical);
			float height = Terrain.activeTerrain.SampleHeight(location);
			height += .01f;
        	turd.transform.position = new Vector3(horizontal, height, vertical);
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}