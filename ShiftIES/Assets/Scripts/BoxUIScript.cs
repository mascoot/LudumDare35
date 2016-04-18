using UnityEngine;
using System.Collections;

public class BoxUIScript : MonoBehaviour {

	private GameObject formation;
	private Rigidbody2D rb;
	private FormationScript fs;
	public float scaleFactorX;
	public float scaleFactorY;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		formation = GameObject.Find("Formation");
		fs = formation.GetComponent<FormationScript>();
	}

	// Update is called once per frame
	void Update()
	{
		//Vector3 vel = (formation.transform.position - transform.position).normalized;
		//vel *= (formation.GetComponent<FormationScript>().movementSpeed * Time.deltaTime);
		//rb.velocity = vel;
		transform.position = formation.transform.position;
		transform.localScale = new Vector3(fs.currentYScale * scaleFactorY, fs.currentXScale * scaleFactorX, 0.0f);
		//transform.localScale = 
		//	new Vector3(formation.transform.localScale.y * scaleFactorY,
		//	formation.transform.localScale.x * scaleFactorX, 0.0f);
		transform.rotation = formation.transform.rotation;
	}


  void OnCollisionEnter2D(Collision2D col)
  {

  } 
}
