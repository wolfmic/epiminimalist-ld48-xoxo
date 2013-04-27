using UnityEngine;
using System.Collections;

public class scoreBox : MonoBehaviour {
	private float scoreBarLenght;
	private int curScore;
	
	// Use this for initialization
	void Start () {
		curScore = 0;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void UpdateScore(int nb) {
		curScore += nb;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
	}
	
	void OnGUI() {
		GUI.TextArea(new Rect(10, Screen.height - 30, scoreBarLenght * 10, 20), "Score : " + curScore);	
	}
}
