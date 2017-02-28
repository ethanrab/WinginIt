using UnityEngine;
using System.Collections;

public class BirdRay : MonoBehaviour {

	public float rayLength;

	// Update is called once per frame
	void FixedUpdate () {

		RaycastHit hit;
		Ray birdRay = new Ray (transform.position, transform.forward);


		Debug.DrawRay (transform.position, transform.forward * rayLength);

		if (Physics.Raycast (birdRay, out hit, rayLength)) {
			if (hit.collider.tag == "bird") {
				Debug.Log ("You've found a bird");
			}
		}
	}
}
