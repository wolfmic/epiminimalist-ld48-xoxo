using UnityEngine;
using System.Collections;

public class deleteCube : MonoBehaviour {
	private GameObject myCamera;
	public float timeoutFrz = 10;
	public float timeoutJmp = 2;
	public GameObject greenSpot;
	public GameObject redSpot;
	int incR = 0;
	int incG = 0;
	
	// Use this for initialization
	void Start () {
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		
		Vector3 pos = Camera.main.transform.position;
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
		Vector3 target = camera.ViewportToWorldPoint(Input.mousePosition);
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
			scoreBox sb = (scoreBox)myCamera.GetComponent("scoreBox");

			Ray	ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (clickedObj != null) {
				GameObject[] ObjList = GameObject.FindGameObjectsWithTag("Destroyable");
				if (clickedObj.tag == "Destroyable") {
					Destroy(clickedObj);
					sb.UpdateScore(2);
					StartCoroutine(fireSpotlightGreen(clickedObj));
				}
				else if (clickedObj.tag == "JumpBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, 10, 0);
						Obj.GetComponent<LifeSpawned>().timeOutJump(timeoutJmp);
						Obj.rigidbody.drag = 5;
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "FreezeBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.drag = 200;
						Obj.GetComponent<LifeSpawned>().timeOutJump(2);
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "AccelBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.rigidbody.velocity = new Vector3(0, -20, 0);
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "DestroyBonus") {
					foreach(GameObject Obj in ObjList) {
						Obj.GetComponent<LifeSpawned>().timeOutDestroy(0);
					}
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "LifeBonus") {
					StartCoroutine(fireSpotlightGreen(clickedObj));
					Destroy(clickedObj);
				}
				else if (clickedObj.tag == "DieBonus") {
					StartCoroutine(fireSpotlightRed(clickedObj));
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
