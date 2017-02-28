using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

	public GameObject bird;
	public GameObject BirdPathLock;
	public GameObject BirdPathStart;
	//public GameObject BirdPathLand;
	public Transform BirdPathOrigin;
	public int birdCondition = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		if (Input.GetKeyDown (KeyCode.I)) {
			switch (birdCondition) {
			case 2:
				print ("yeah case 2 works");
				Instantiate (bird, BirdPathOrigin.position, BirdPathOrigin.rotation);
				//Instantiate (BirdPathLand, BirdPathOrigin.position, BirdPathOrigin.rotation);
				Instantiate (BirdPathStart, BirdPathOrigin.position, BirdPathOrigin.rotation);
				break;
			case 1:
				print ("yeah it works");
				Instantiate (bird, BirdPathOrigin.position, BirdPathOrigin.rotation);
				Instantiate (BirdPathLock, BirdPathOrigin.position, BirdPathOrigin.rotation);
				Instantiate (BirdPathStart, BirdPathOrigin.position, BirdPathOrigin.rotation);
				break;
			default:
				print ("default error");
				break;

			}
		}
	}
}
