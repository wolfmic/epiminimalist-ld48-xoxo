using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUISkin newGame; 
	public GUISkin quitGame;
	public GUISkin credit;
	public Texture _newGameText;
	public Texture _quitGameText;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = newGame;
		Rect RectNewGame = new Rect(Screen.width / 2 - _newGameText.width / 2, Screen.height / 2 - _newGameText.height / 2, _newGameText.width, _newGameText.height);
		if (GUI.Button(RectNewGame, ""))
			Application.LoadLevel(2);
		
		GUI.skin = quitGame;
		Rect RectQuitGame = new Rect(Screen.width / 2 - _quitGameText.width / 2, Screen.height / 2 + _quitGameText.height + _quitGameText.height, _quitGameText.width, _quitGameText.height);
		if (GUI.Button(RectQuitGame, ""))
			Application.Quit();
		
		GUI.skin = credit;
		Rect RectCreditGame = new Rect(Screen.width / 2 - _newGameText.width / 2, Screen.height / 2 + _quitGameText.height - _quitGameText.height / 4, _newGameText.width, _quitGameText.height);
		if (GUI.Button(RectCreditGame, ""))
			Application.LoadLevel(1);
		
	}
}