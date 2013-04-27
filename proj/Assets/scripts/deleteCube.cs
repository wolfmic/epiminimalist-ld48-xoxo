using UnityEngine;
using System.Collections;

public class deleteCube : MonoBehaviour {
	public float timeoutFrz = 10;
	public float timeoutJmp = 2;
	private GameObject myCamera;
	
	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	GameObject GetClickedGameObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
			return hit.transform.gameObject;
		else {
			return null;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject clickedObj = null;
		if (Input.GetMouseButtonDown(0)) {
			clickedObj = GetClickedGameObject();
			scoreBox sb = (scoreBox)myCamera.GetComponent("scoreBox");
			if (clickedObj != null) {
				if (clickedObj.tag == "Destroyable") {
					Destroy(clickedObj);
					sb.UpdateScore(2);
				}
				GameObject[] ObjList = GameObject.FindGameObjectsWithTag("Destroyable");
				if (clickedObj.tag == "JumpBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, 10, 0);
						Obj.GetComponent<LifeSpawned>().timeOutJump(timeoutJmp);
						Obj.rigidbody.drag = 5;
					}
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "FreezeBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.drag = 200;
						Obj.GetComponent<LifeSpawned>().timeOutJump(2);
					}
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "AccelBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, -20, 0);
					}
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "DestroyBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.GetComponent<LifeSpawned>().timeOutDestroy(0);
					}
					Destroy(clickedObj);
				}
			} else {
					sb.UpdateScore(-1);
			}
		}
	}
	
	
}
