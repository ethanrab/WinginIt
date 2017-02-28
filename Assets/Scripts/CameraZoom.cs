using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour {
	public int zoom;
	public int normal = 60;
	public float smooth = 5;
	public Camera photocamera;
	public int howZoomed;
	public GameObject _overlay;
	public Screenshot _screenshot;

	private bool isZoomed = false;
	public bool overlayOn = false;

	void Start(){
		howZoomed = 1;
		zoom = 50;
		//_overlay.SetActive (overlayOn);
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.C)) {
			isZoomed = !isZoomed;
			overlayOn = !overlayOn;
		}

		if (isZoomed) {
			photocamera.fieldOfView = Mathf.Lerp (photocamera.fieldOfView, zoom, Time.deltaTime * smooth);
			//_overlay.SetActive (true);
		} else {
			photocamera.fieldOfView = Mathf.Lerp (photocamera.fieldOfView, normal, Time.deltaTime * smooth);
			//_overlay.SetActive (false);
		}

		if (overlayOn == true){
			_overlay.SetActive (true);
		} else {
			_overlay.SetActive (false);
		}


		if (Input.GetKeyDown (KeyCode.V) && isZoomed == true && howZoomed < 5) {
			howZoomed += 1;
		}

		if (Input.GetKeyDown (KeyCode.B) && isZoomed == true && howZoomed > 1) {
			howZoomed -= 1;
		}

		switch (howZoomed) {
		case 1:
			zoom = 50;
			break;
		case 2:
			zoom = 40;
			break;
		case 3:
			zoom = 30;
			break;
		case 4:
			zoom = 20;
			break;
		case 5:
			zoom = 10;
			break;
		}
	}

}
