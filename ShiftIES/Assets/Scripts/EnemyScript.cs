using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speedOfMovement;
	private Animator anim;
	private SpriteRenderer sr;
  GameObject player;
  Vector3 MovDir;
	//private GameObject formation;

	// Use this for initialization
	void Start () {
    player = GameObject.Find("Formation");
    MovDir = player.transform.position - transform.position;
    MovDir.Normalize();
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		//formation = GameObject.Find("Formation");
	}
	
	// Update is called once per frame
	void Update () {
    transform.position += MovDir * speedOfMovement * Time.deltaTime;
		anim.Play("enemyIdle"); // temp (add conditions later)
	}

  void attack()
  {

  }

  void WrapAround()
  {

  }
  void OnCollisionEnter2D(Collision2D coll)
  {

  }
}
