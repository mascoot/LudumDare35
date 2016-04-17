using UnityEngine;
using System.Collections;

public class Unit1Script : MonoBehaviour {

	public Vector3 positionToGo;
	public float speedOfMovement;
  public GameObject bullet;
  public float bulletSpeed = 10.0f;
  public float firingSpeed = 2.0f;

	private GameObject formation;
  private float firingInterval = 0.0f;

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
    GameObject tmp = Instantiate(bullet, trans.position, Quaternion.identity) as GameObject;
    tmp.GetComponent<Rigidbody2D>().AddForce(formation.transform.up * bulletSpeed);
  }
}
