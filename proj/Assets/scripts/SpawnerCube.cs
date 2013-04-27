using UnityEngine;
using System.Collections;

public class SpawnerCube : MonoBehaviour {

	public int y = 0;
	public Vector2 limit_x = new Vector2(0,0);
	public GameObject newObj;
	public float timer = 1;
	
	private float prev_time = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float now = Time.time;
		
		if (now - prev_time > timer)
		{
			Vector3 scenePos = this.gameObject.transform.position;
			float x = Random.Range(limit_x.x, limit_x.y);
			Vector3 pos = new Vector3(x,scenePos.y + y,scenePos.z);

			Instantiate(newObj, pos, Quaternion.identity);
			prev_time = now;
		}
	}
}
