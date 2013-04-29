using UnityEngine;
using System.Collections;

public class scoreBox : MonoBehaviour {
	private float scoreBarLenght;
	private float fallenCubeLenght;
	private int curScore;
	private int curLife;
	private int fallenCube;
	public GameObject lifeCube;
	public GUISkin skin;
	
	// Use this for initialization
	void Start () {
		fallenCube = 0;
		curScore = 0;
		curLife = 3;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
		fallenCubeLenght = "Fallen Cube".Length + fallenCube.ToString().Length;
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.LoadLevel(0);
		}
		
		if (curLife < 0){
			Application.LoadLevel(3);
		}
	}
	
	public void UpdateLife(int nb) {
		curLife += nb;	
	}
	
	public void UpdateScore(int nb) {
		curScore += nb;
		scoreBarLenght = "Score  ".Length + curScore.ToString().Length;
	}
	
	public void deleteCube() {
		fallenCube++;
		if (fallenCube == 20) {
			fallenCube = 0;
			UpdateLife(-1);
		}
		fallenCubeLenght = "Fallen Cube".Length + fallenCube.ToString().Length;
	}
	
	void OnGUI() {
		int i = 0;

		GUI.TextArea(new Rect(10, Screen.height - 90, 110, 20), "Fallen cubes : " + fallenCube);	
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
