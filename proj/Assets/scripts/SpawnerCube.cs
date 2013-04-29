using UnityEngine;
using System.Collections;

public class SpawnerCube : MonoBehaviour {
	public int y = 0;
	public Vector2 limit_x = new Vector2(0,0);
	public GameObject newObj;
	public float timer = 1;
	private GameObject myCamera;
	private scoreBox sb;
	private float prev_time = 0;
	float my_timer;
	
	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		sb = (scoreBox)myCamera.GetComponent("scoreBox");
		my_timer = timer;
	}
	
	float changeTimer(string tag) {
		if (newObj.tag == "Destroyable") { // Increment timer for simple cube
			my_timer = timer - (float)(sb.getScore() / 50f) / 10f;
			if (my_timer < 0.1)
				my_timer = 0.1f;
		} else if (newObj.tag == "DieBonus") {
			my_timer = Random.Range(10, 15);
		} else if (newObj.tag == "LifeBonus") {
			my_timer = Random.Range(30, 50);	
		} else if (newObj.tag == "DestroyBonus") {
			my_timer = Random.Range(25, 50);
		} else if (newObj.tag == "ObligedBonus") {
			my_timer = Random.Range(5, 10);
		} else if (newObj.tag == "FreezeBonus") {
			my_timer = Random.Range(7, 12);
			Debug.Log ("Timer obliged : "+my_timer);
		} else {
			my_timer = timer;
		}
		return (my_timer);
	}
	
	// Update is called once per frame
	void Update () {
		float now = Time.time;
		
		if (now - prev_time > my_timer)
		{
			my_timer = changeTimer(newObj.tag);
			Vector3 scenePos = this.gameObject.transform.position;
			float x = Random.Range(limit_x.x, limit_x.y);
			Vector3 pos = new Vector3(x,scenePos.y + y,scenePos.z);
			
			Instantiate(newObj, pos, Quaternion.identity);
			prev_time = now;
		}
	}
}
