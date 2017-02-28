using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour {

	Texture2D screenCap;
	public bool shot = false;
	public GameObject _overlay;
	public CameraZoom _cam;
	public int birdIdentity = 1;
	public Image stock;

	// Use this for initialization
	void Start () {
		screenCap = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.N)){
			StartCoroutine("Capture");
		}
	}

	void OnGUI(){
		if (shot) {
			GUI.DrawTexture (new Rect (10, 10, 60, 40), screenCap, ScaleMode.StretchToFill);
		}
	}

	IEnumerator Capture(){
		_cam.overlayOn = false;
		yield return new WaitForEndOfFrame ();
		screenCap.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		screenCap.Apply ();

		byte[] bytes = screenCap.EncodeToPNG ();

		shot = true;
		_cam.overlayOn = true;
		stock.material.mainTexture = screenCap;

		switch (birdIdentity){
		case 1:
			File.WriteAllBytes (Application.dataPath + "/SavedScreen.png", bytes);
			break;
		case 2:
			File.WriteAllBytes (Application.dataPath + "/FartAttack.png", bytes);
			break;
		}
	}
}
