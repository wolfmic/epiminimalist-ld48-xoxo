using UnityEngine;
using System.Collections;

public class scoreBox : MonoBehaviour {
	private float scoreBarLenght;
	private int curScore;
	private int curLife;
	public GameObject lifeCube;
	public GUISkin skin;
	
	// Use this for initialization
	void Start () {
		curScore = 0;
		curLife = 3;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void UpdateLife(int nb) {
		curLife += nb;	
	}
	
	public void UpdateScore(int nb) {
		curScore += nb;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
	}
	
	void OnGUI() {
		int i = 0;
		
		GUI.TextArea(new Rect(10, Screen.height - 60, scoreBarLenght * 10, 20), "Score : " + curScore);	
		GUI.TextArea(new Rect(10, Screen.height - 30, 40, 20), "Life : ");
		GUI.skin = skin;
		while (i < curLife)
		{
			GUI.Box(new Rect(60 + (i * 30), Screen.height - 30, 20, 20), "");
			i++;
		}
	}
	
	public int getScore() {
		return (curScore);	
	}
}
