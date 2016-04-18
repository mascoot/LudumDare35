using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Vector3 positionToGo;
	public float speedOfMovement;
	private Animator anim;
	private SpriteRenderer sr;
	//private GameObject formation;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		//formation = GameObject.Find("Formation");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveVec3 = positionToGo - transform.position;
		Vector2 moveVec2 = new Vector2(moveVec3.x, moveVec3.y);
		if (moveVec2.magnitude > 1.0f) moveVec2.Normalize();
		Vector3 finalMovement = new Vector3(moveVec2.x, moveVec2.y) * speedOfMovement;

		anim.Play("enemyIdle"); // temp (add conditions later)

		transform.position += finalMovement;
	}
}
