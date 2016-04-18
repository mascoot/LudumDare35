using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float speedOfMovement;
	private Animator anim;
	private SpriteRenderer sr;
  GameObject player;
  Vector3 MovDir;
  public GameObject unit;
  public GameObject ES;
  public GameObject Formation;
  private GameObject GM;
	//private GameObject formation;

	// Use this for initialization
	void Start () {
    Formation = GameObject.Find("Formation");
    ES = GameObject.Find("EnemySpawner");
    player = GameObject.Find("Formation");
    MovDir = player.transform.position - transform.position;
    MovDir.Normalize();
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
    GM = GameObject.Find("GameManager");
		//formation = GameObject.Find("Formation");
    
    //GetComponent<ParticleEmitter>().play
	}
	
	// Update is called once per frame
	void Update () {

    if (GM.GetComponent<GameManagerScript>().IsPaused()) return;

    transform.position += MovDir * speedOfMovement * Time.deltaTime;
		anim.Play("enemyIdle"); // temp (add conditions later)

    WrapAround();
	}


  void WrapAround()
  {
    float limit = 40.0f;

    if (Mathf.Abs(transform.position.x) > limit || Mathf.Abs(transform.position.y) > limit)
    {
      ES.GetComponent<EnemySpawnScript>().KillEnemy();
      Destroy(this.gameObject);
    }
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.tag == "PlayerBullet")
    {
      Instantiate(unit, gameObject.transform.position, Quaternion.identity);
      ES.GetComponent<EnemySpawnScript>().KillEnemy();
      Destroy(this.gameObject);
      return;
    }

    if(coll.gameObject.tag == "PlayerBox")
    {
      Formation.GetComponent<FormationScript>().KillUnits(0.33f);
      ES.GetComponent<EnemySpawnScript>().KillEnemy();
      Destroy(this.gameObject);
      return;
    }
  }
}
