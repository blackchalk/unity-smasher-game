// Just add this script to your camera. It doesn't need any configuration.

using UnityEngine;
using UnityEngine.UI;


public class TouchCamera : MonoBehaviour {
//	Vector2?[] oldTouchPositions = {
//		null,
//		null
//	};
//	Vector2 oldTouchVector;
//	float oldTouchDistance;
////	public Camera camera;
//
//
//	void Update() {
//		if (Input.touchCount == 0) {
//			oldTouchPositions[0] = null;
//			oldTouchPositions[1] = null;
//		}
//		else if (Input.touchCount == 1) {
//			if (oldTouchPositions[0] == null || oldTouchPositions[1] != null) {
//				oldTouchPositions[0] = Input.GetTouch(0).position;
//				oldTouchPositions[1] = null;
//			}
//			else {
//				Vector2 newTouchPosition = Input.GetTouch(0).position;
//				
//				transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] - newTouchPosition) * this.gameObject.GetComponent<Camera>().orthographicSize / this.gameObject.GetComponent<Camera>().pixelHeight * 2f));
//				
//				oldTouchPositions[0] = newTouchPosition;
//			}
//		}
//		else {
//			if (oldTouchPositions[1] == null) {
//				oldTouchPositions[0] = Input.GetTouch(0).position;
//				oldTouchPositions[1] = Input.GetTouch(1).position;
//				oldTouchVector = (Vector2)(oldTouchPositions[0] - oldTouchPositions[1]);
//				oldTouchDistance = oldTouchVector.magnitude;
//			}
//			else {
//				Vector2 screen = new Vector2(this.gameObject.GetComponent<Camera>().pixelWidth, this.gameObject.GetComponent<Camera>().pixelHeight);
//				
//				Vector2[] newTouchPositions = {
//					Input.GetTouch(0).position,
//					Input.GetTouch(1).position
//				};
//				Vector2 newTouchVector = newTouchPositions[0] - newTouchPositions[1];
//				float newTouchDistance = newTouchVector.magnitude;
//
//				transform.position += transform.TransformDirection((Vector3)((oldTouchPositions[0] + oldTouchPositions[1] - screen) * this.gameObject.GetComponent<Camera>().orthographicSize / screen.y));
//				transform.localRotation *= Quaternion.Euler(new Vector3(0, 0, Mathf.Asin(Mathf.Clamp((oldTouchVector.y * newTouchVector.x - oldTouchVector.x * newTouchVector.y) / oldTouchDistance / newTouchDistance, -1f, 1f)) / 0.0174532924f));
//				this.gameObject.GetComponent<Camera>().orthographicSize *= oldTouchDistance / newTouchDistance;
//				transform.position -= transform.TransformDirection((newTouchPositions[0] + newTouchPositions[1] - screen) * this.gameObject.GetComponent<Camera>().orthographicSize / screen.y);
//
//				oldTouchPositions[0] = newTouchPositions[0];
//				oldTouchPositions[1] = newTouchPositions[1];
//				oldTouchVector = newTouchVector;
//				oldTouchDistance = newTouchDistance;
//			}
//		}


	public float scrollSpeed = 10.0f;
	public GameObject[] maps;

	Camera mainCamera;

	private float topBound;
	private float bottomBound;
	private Vector3 pos;
	private SpriteRenderer currentSprite;
	private int mapIndex;
	void Awake () 
	{
		mapIndex = 0;
		mainCamera = Camera.main;
		currentSprite = maps [mapIndex].GetComponent<SpriteRenderer> ();
		bottomBound = currentSprite.sprite.bounds.size.y * -1;
		topBound = currentSprite.sprite.bounds.size.y + currentSprite.gameObject.transform.position.y;
	}

	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved)
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			mainCamera.transform.Translate(0f,-touchDeltaPosition.y * scrollSpeed * Time.deltaTime,0f);

		}

	}

	private float getAxisDelta(float axisDelta,float camMin,float camMax,float bottom,float top)
	{
		//get where edge of camera will have moved if full translate is done
		float boundaryMinPixelsDestination = camMin - Mathf.Abs(axisDelta);
		float boundaryMaxPixelsDestination = camMax + Mathf.Abs(axisDelta);

		Debug.Log("MaxPixels:"+boundaryMaxPixelsDestination+"="+camMax+"+"+Mathf.Abs(axisDelta));
		//check to see if you're within the border
		if ((boundaryMinPixelsDestination <= bottom && axisDelta > 0) ||
			(boundaryMaxPixelsDestination >= top && axisDelta < 0))
		{
			axisDelta = 0;
		}

		return axisDelta;

	}

	private float camBoundPos(string pos)
	{
		float bounds = 0f;
		if (pos == "top")
			bounds = mainCamera.transform.position.y + mainCamera.orthographicSize;
		if(pos == "bottom")
			bounds = mainCamera.transform.position.y - mainCamera.orthographicSize;

		return bounds;
	}
		}
	