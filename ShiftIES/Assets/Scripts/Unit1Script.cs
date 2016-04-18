using UnityEngine;
using System.Collections;

public class Unit1Script : MonoBehaviour {

	public Vector3 positionToGo;
	public float speedOfMovement;
  public GameObject bullet;

  private Animator anim;
	private SpriteRenderer sr;
	private GameObject formation;

	private float speedToQualifyAsRun;
	//private int idleHash;
	//private int walkHash;


	// Use this for initialization
	void Start () {
		speedToQualifyAsRun = 0.5f;
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
		bool isRangeAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("range");

		if ((!isRangeAnim)  || (isRangeAnim && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f))
		{
			// MAGIC NUMBER!
			print(moveVec2.magnitude);
			if (moveVec2.magnitude > speedToQualifyAsRun) anim.Play("walk");
			else anim.Play("Idle");

			if (moveVec2.x > 0.0001f) sr.flipX = false;
			else if (moveVec2.x < -0.0001f) sr.flipX = true;
		}

		if (moveVec2.magnitude > 1.0f) moveVec2.Normalize();
		Vector3 finalMovement = new Vector3(moveVec2.x, moveVec2.y) * speedOfMovement * Time.deltaTime;
		transform.position += finalMovement;
  }

  public void FireForEffect(float bulletSpeed)
  {
      FireBullet(transform, bulletSpeed);

		if (Mathf.Cos(formation.transform.localRotation.eulerAngles.z * Mathf.Deg2Rad) >= 0) sr.flipX = false;
		else sr.flipX = true;

    anim.Play("range");
	}

  void FireBullet(Transform trans, float bulletSpeed)
  {
    GameObject tmp = Instantiate(bullet, trans.position, Quaternion.Euler(0,0, formation.transform.localRotation.eulerAngles.z)) as GameObject;
    tmp.GetComponent<Rigidbody2D>().AddForce(formation.transform.right * bulletSpeed);
  }
}
