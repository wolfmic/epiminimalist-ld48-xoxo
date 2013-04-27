using UnityEngine;
using System.Collections;

public class LifeSpawned : MonoBehaviour {
	
	public int limit_y = 0;
	
	// Use this for initialization
	void Start () {
		Debug.Log("TOTO");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y <= limit_y)
		{
			Destroy(this.gameObject);
		}
	}
}
