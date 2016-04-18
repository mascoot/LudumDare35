using UnityEngine;
using System.Collections;

public class Unit1Script : MonoBehaviour {

	public Vector3 positionToGo;
	public float speedOfMovement;
  public GameObject bullet;
  public float bulletSpeed = 10.0f;
  public float firingSpeed = 2.0f;

	private Animator anim;
	private SpriteRenderer sr;
	private GameObject formation;
  private float firingInterval = 0.0f;
	private int idleHash;
	private int walkHash;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		formation = GameObject.Find("Formation");
	}

	void Awake (){
		//idleHash = Animator.StringToHash("idle");
		//walkHash = Animator.StringToHash("walk");
	}

	// Update is called once per frame
	void Update () {
		Vector3 moveVec3 = positionToGo - transform.position;
		Vector2 moveVec2 = new Vector2(moveVec3.x, moveVec3.y);

		// MAGIC NUMBER!
		if(moveVec2.magnitude > 0.1f) anim.Play("walk");
		else anim.Play("Idle");

		if (moveVec2.x > 0.0001f) sr.flipX = false;
		else if (moveVec2.x < -0.0001f) sr.flipX = true;
		

		
		if (moveVec2.magnitude > 1.0f) moveVec2.Normalize();
		Vector3 finalMovement = new Vector3(moveVec2.x, moveVec2.y) * speedOfMovement * Time.deltaTime;
		transform.position += finalMovement;

    FireForEffect();
  }

  void FireForEffect()
  {
    firingInterval -= Time.deltaTime;
    if(firingInterval <= 0.0f)
    {
      FireBullet(transform);
      firingInterval = firingSpeed;
    }
  }

  void FireBullet(Transform trans)
  {
    GameObject tmp = Instantiate(bullet, trans.position, Quaternion.Euler(0,0, formation.transform.localRotation.eulerAngles.z)) as GameObject;
    tmp.GetComponent<Rigidbody2D>().AddForce(formation.transform.right * bulletSpeed);
  }
}
