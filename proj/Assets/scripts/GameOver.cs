using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		if (timer > 10)
			Application.LoadLevel(0);
	}
}
