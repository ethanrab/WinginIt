using UnityEngine;
using System.Collections;

public class BirdDeath : MonoBehaviour {
	
	void Update () {
		Destroy (gameObject, 30);
	}
}
