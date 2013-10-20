using UnityEngine;
using System.Collections;

public class GUI_HUD : MonoBehaviour {
	

	public GameObject scoreText;
	public GUIStyle gameStyle;
	public GUIStyle gameStyleShadow;
	public Font JellyBelly;
	public Rect shadowRect;
	public Rect scoreRect;
	
	void Start()
	{
		JellyBelly = (Font)Resources.Load("Fonts/JellyBelly", typeof(Font));
		shadowRect = new Rect(Screen.width/2 - 53, 3, Screen.width/2 + 103,53);
		scoreRect = new Rect(Screen.width/2 - 50, 0, Screen.width/2 + 100,50);
		gameStyleShadow = new GUIStyle();
		gameStyle = new GUIStyle();
		scoreText = new GameObject();
	}
	
		
	void OnGUI()
	{
		//GUIText gText = (GUIText)scoreText.AddComponent(typeof(GUIText));
		
		//gText.font = JellyBelly;
		gameStyle.font = JellyBelly;
		gameStyle.normal.textColor = Color.green;
		gameStyle.fontSize = 45;
		gameStyleShadow.font = JellyBelly;
		gameStyleShadow.normal.textColor = Color.black;
		gameStyleShadow.fontSize = 45;
		//gText.transform.position = new Vector3(XPos, YPos, 0.0f);
		//float textWidth = gameStyle.CalcSize(new GUIContent(gText.text)).x;
		//float textHeight = gameStyle.CalcSize(new GUIContent(gText.text)).y;
		//gText.material.color = Color.green;
		
		GUI.Label(shadowRect, "Score\n" + ScoreManager.playerScore.ToString(), gameStyleShadow);
		GUI.Label(scoreRect, "Score\n" + ScoreManager.playerScore.ToString(), gameStyle);
		//gText.text = "Score\n" + ScoreManager.playerScore.ToString();
		
	}
}
