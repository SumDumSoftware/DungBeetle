using UnityEngine;
using System.Collections;

public class GUI_HUD : MonoBehaviour {
	
	public GameObject scoreText = new GameObject();
	public GUIStyle gameStyle = new GUIStyle();
	
		
	void OnGUI()
	{
		GUIText gText = (GUIText)scoreText.AddComponent(typeof(GUIText));
		Font Eastwood = (Font)Resources.Load("Fonts/JellyBelly", typeof(Font));
		gText.font = Eastwood;
		gameStyle.font = Eastwood;
		gText.fontSize = 45;
		float XPos = 400.0f / Screen.width;
		float YPos = 300.0f / Screen.height;
		gText.transform.position = new Vector3(XPos, YPos, 0.0f);
		float textWidth = gameStyle.CalcSize(new GUIContent(gText.text)).x;
		float textHeight = gameStyle.CalcSize(new GUIContent(gText.text)).y;
		gText.material.color = Color.green;
		GUI.Label(new Rect(450, 0, 250,250), "Score\n" + ScoreManager.playerScore.ToString(), gameStyle);
		gText.text = "Score\n" + ScoreManager.playerScore.ToString();
		
	}
}
