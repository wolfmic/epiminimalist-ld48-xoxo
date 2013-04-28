using UnityEngine;
using System.Collections;

public class deleteCube : MonoBehaviour {
	private GameObject myCamera;
	public float timeoutFrz = 10;
	public float timeoutJmp = 2;
	public GameObject greenSpot;
	public GameObject redSpot;
	private scoreBox sb;
	int incR = 0;
	int incG = 0;
	
	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		sb = (scoreBox)myCamera.GetComponent("scoreBox");

		greenSpot.SetActive(false);
		redSpot.SetActive(false);
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
	
	IEnumerator fireSpotlightGreen(GameObject gO)
	{
		greenSpot.SetActive(true);
		greenSpot.transform.LookAt(gO.transform);
		incG++;
		yield return new WaitForSeconds(0.3f);
		incG--;
		if (incG == 0) {
			greenSpot.SetActive(false);
		}
	}
	
	IEnumerator fireSpotlightRed()
	{
		redSpot.SetActive(true);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		redSpot.transform.LookAt(ray.GetPoint(1));
		incR++;
		yield return new WaitForSeconds(0.3f);
		incR--;
		if (incR == 0) {
			redSpot.SetActive(false);
		}
	}
	// Update is called once per frame
	void Update () {
		GameObject clickedObj = null;
		if (Input.GetMouseButtonDown(0)) {
			clickedObj = GetClickedGameObject();

			if (clickedObj != null) {
				GameObject[] ObjList = GameObject.FindGameObjectsWithTag("Destroyable");
				if (clickedObj.tag == "Destroyable") { // BASIC CUBE
					Destroy(clickedObj);
					sb.UpdateScore(2);
					StartCoroutine(fireSpotlightGreen(clickedObj));
				}
				else if (clickedObj.tag == "JumpBonus") { // JUMP CUBE
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, 10, 0);
						Obj.GetComponent<LifeSpawned>().timeOutJump(timeoutJmp);
						Obj.rigidbody.drag = 5;
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "FreezeBonus") { // FREEZE CUBE
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.drag = 200;
						Obj.GetComponent<LifeSpawned>().timeOutJump(2);
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "AccelBonus") { // ACCELERATOR CUBE
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, -20, 0);
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "DestroyBonus") { // DETROYER CUBE
					int j = 0;
					foreach(GameObject Obj in ObjList) {
						Obj.GetComponent<LifeSpawned>().timeOutDestroy(0);
						j++;
					}
					sb.UpdateScore(10);
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "LifeBonus") { // +1 LIFE CUBE
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
					sb.UpdateLife(1);
				}
				else if (clickedObj.tag == "DieBonus") { // -1 LIFE CUBE
					StartCoroutine(fireSpotlightRed());
					Destroy(clickedObj);
					sb.UpdateLife(-1);
				}
				else if (clickedObj.tag == "PopBonus") {
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "PopBonus") {
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}

				else {
					sb.UpdateScore(-1);
					StartCoroutine(fireSpotlightRed());
				}
			} else {
					sb.UpdateScore(-1);
					StartCoroutine(fireSpotlightRed());
			}
		}
	}
	
	
}
