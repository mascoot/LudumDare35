using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	private GameObject formation;

	// Use this for initialization
	void Start () {
		formation = GameObject.Find("Formation");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = formation.transform.position;
		transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		transform.rotation = formation.transform.rotation;
	}
}
