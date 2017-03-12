using UnityEngine;
using System.Collections;

public class DraggingScript : MonoBehaviour {

	public GameObject gameObjectTodrag;
	public Vector3 GOCenter;
	public Vector3 touchPosition;
	public Vector3 offset;
	public Vector3 newGOCenter;

	RaycastHit hit;

	public bool draggingMode = false;


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				gameObjectTodrag = hit.collider.gameObject;
				GOCenter = gameObjectTodrag.transform.position;
				touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//offset = touchPosition - GOCenter;
				draggingMode = true;
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			if (draggingMode) {
				touchPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				newGOCenter = touchPosition ;
				gameObjectTodrag.transform.position = new Vector3 (GOCenter.x, newGOCenter.y, GOCenter.z);
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			draggingMode = false;
		}
	}

}
