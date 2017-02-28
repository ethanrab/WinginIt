using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _onlineshop : MonoBehaviour {

	public Canvas _shopUI;
	public GameObject _player;
	public Camera _cam;
	public bool inWebsite = false;

	void Start(){
		_cam.enabled = false;
		_shopUI.gameObject.SetActive(false);
		Debug.Log (_shopUI.isActiveAndEnabled);
	}
		
	void OnTriggerStay (Collider col) {
		if (Input.GetKeyDown (KeyCode.E) &&  inWebsite == false) {
			_shopUI.gameObject.SetActive (true);
			_player.SetActive (false);
			_cam.enabled = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			inWebsite = true;
		} 
	}

	public void CloseShop(){
		_cam.enabled = false;
		_shopUI.gameObject.SetActive (false);
		inWebsite = false;
		_player.SetActive (true);
	}
}
