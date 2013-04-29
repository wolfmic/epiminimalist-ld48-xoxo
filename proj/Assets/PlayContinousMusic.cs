using UnityEngine;
using System.Collections;

public class PlayContinousMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 1)
			DestroyImmediate(this);
		if (Application.loadedLevel == 3)
			DestroyImmediate(this);
	}
	
	void Awake () {
		DontDestroyOnLoad(this);
		audio.loop = true;

	}
}
