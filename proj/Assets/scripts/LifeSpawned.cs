using UnityEngine;
using System.Collections;

public class LifeSpawned : MonoBehaviour {
	
	public int limit_y = 0;
	private float timeout = 0;
	private bool timeActivatedJump = false;
	private bool timeActivatedDestroy = false;
	private GameObject myCamera;
	private scoreBox sb;
	
	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		sb = (scoreBox)myCamera.GetComponent("scoreBox");
	}
	
	public void timeOutJump (float t) {
		timeout = t;
		timeActivatedJump = true;
	}
	
	public void timeOutDestroy (float t) {
		timeout = t;
		timeActivatedDestroy = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y <= limit_y)
		{
			if (this.gameObject.tag == "ObligedBonus")
			{
				sb.UpdateLife(-1);
			}
			Destroy(this.gameObject);
		}
		timeout -= Time.deltaTime;
		if (timeActivatedDestroy == true) {
			if (timeout <= 0) {
				Destroy(this.gameObject);
				timeActivatedDestroy = false;
				timeout = 0;
			}
		}
		if (timeActivatedJump == true) {
			if (timeout <= 0) {
				timeActivatedJump = false;
				this.rigidbody.drag = 1;
				timeout = 0;
			}
		}
	}
}