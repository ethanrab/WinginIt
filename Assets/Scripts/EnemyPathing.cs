using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyPathing : MonoBehaviour {

	public Transform[] path;
	public float speed = 5.0f;
	public float smooth = 1.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;
	public PathNodeArray PathNodeScript;
	private Transform startPoint;
	private Transform endPoint;
	private Transform[] flyingPoints;
	public int flyingLength;


	void Start()
	{
		flyingPoints = new Transform[flyingLength];
		CreatePath ();
	}

	void CreatePath () {
		startPoint = PathNodeScript.startPoints [Random.Range (0, PathNodeScript.startPoints.Length)];
		//flyingPoints = PathNodeScript.flyingPoints [Random.Range (0, PathNodeScript.flyingPoints.Length)];
		endPoint = PathNodeScript.landingPoints [Random.Range (0, PathNodeScript.landingPoints.Length)];

		for (int i = 0; i < flyingPoints.Length; i++) 
		{
			flyingPoints [i] = PathNodeScript.flyingPoints [i];
		}

		path [0] = startPoint;
		for (int i = 0; i < flyingPoints.Length; i++) {
			path [i] = flyingPoints [i];
		}
		path [flyingLength] = endPoint;
	}

	void Update () {
		float dist = Vector3.Distance (path [currentPoint].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, path [currentPoint].position, Time.deltaTime * speed);
		//transform.rotation = Quaternion.Slerp (transform.rotation, path [currentPoint].rotation, Time.deltaTime * smooth);
		Vector3 direction = path [currentPoint].position - transform.position;
		Quaternion rotationDirection = Quaternion.LookRotation (direction);
		transform.rotation = rotationDirection;


		
		if (dist <= reachDist) 
		{
			if (currentPoint != path.Length - 1) {
				currentPoint++;
			}
		}

		/*if (currentPoint >= path.Length) 
		{
			currentPoint = 0;
		}*/
			
	}
	
	void OnDrawGizmos ()
	{
		if (path.Length > 0)
		for (int i = 0; i < path.Length; i++){
			if (path[i] != null){
				Gizmos.DrawSphere(path[i].position,reachDist);
			}
		}
	}
		
}
