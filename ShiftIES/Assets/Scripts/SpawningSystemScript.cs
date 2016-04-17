using UnityEngine;
using System.Collections;

public class SpawningSystemScript : MonoBehaviour {

	public GameObject unit1;
	public GameObject Enemy;
  public Camera cam;
	private GameObject unit1Clone;
	//private GameObject formation;

	// Use this for initialization
	void Start () {
		//formation = GameObject.Find("Formation System");
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput();
	}

	void UpdateInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 mouseScreenPos = cam.ScreenToWorldPoint(Input.mousePosition);
			CreateUnit(unit1, new Vector2(mouseScreenPos.x, mouseScreenPos.y));
		}

    //if (Input.GetMouseButtonDown(1))
    //{
    //  Vector3 mouseScreenPos = cam.ScreenToWorldPoint(Input.mousePosition);
    //  CreateUnit(Enemy, new Vector2(mouseScreenPos.x, mouseScreenPos.y));
    //}
  }

	void CreateUnit(GameObject go, Vector2 position)
	{
		unit1Clone = Instantiate(go, position, Quaternion.identity) as GameObject;
		//unit1Clone.transform.parent = formation.transform;
	}
}
