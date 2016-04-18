using UnityEngine;
using System.Collections;

public class BoxUIScript : MonoBehaviour {

	private GameObject formation;
	public float scaleFactorX;
	public float scaleFactorY;

	// Use this for initialization
	void Start()
	{
		formation = GameObject.Find("Formation");
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = formation.transform.position;
		transform.localScale = 
			new Vector3(formation.transform.localScale.y * scaleFactorY,
			formation.transform.localScale.x * scaleFactorX, 0.0f);
		transform.rotation = formation.transform.rotation;
	}
}
