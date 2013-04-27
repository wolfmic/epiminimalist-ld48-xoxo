using UnityEngine;
using System.Collections;

public class SpawnerCube : MonoBehaviour {

	public int x = 0;
	public int y = 0;
	public int width = 150;
	public GameObject newObj;
	
	private float prev_time = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float now = Time.time;
		if ((int)prev_time < (int)now)
		{
			Instantiate(newObj);
		}
		prev_time = now;
	}
}
