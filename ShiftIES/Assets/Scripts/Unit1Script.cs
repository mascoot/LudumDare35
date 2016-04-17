using UnityEngine;
using System.Collections;

public class Unit1Script : MonoBehaviour {

	public Vector3 positionToGo;
	public float speedOfMovement;
	private GameObject formation;

	// Use this for initialization
	void Start () {
		formation = GameObject.Find("Formation");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveVec3 = positionToGo - transform.position;
		Vector2 moveVec2 = new Vector2(moveVec3.x, moveVec3.y);
		if (moveVec2.magnitude > 1.0f) moveVec2.Normalize();
		Vector3 finalMovement = new Vector3(moveVec2.x, moveVec2.y) * speedOfMovement;

		transform.position += finalMovement;
	}
}
