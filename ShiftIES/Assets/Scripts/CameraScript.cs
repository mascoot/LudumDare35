using UnityEngine;
using System.Collections;

public class CameraScript: MonoBehaviour {

	// Use this for initialization
  public GameObject player;
  public float lockX;
  public float lockY;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    Mount();
	}


  void Mount()
  {
    Vector3 newPos = GetComponent<Transform>().position;

    bool locked = false;
    if (Mathf.Abs(player.transform.position.x) < lockX)
    {
      newPos.x = player.GetComponent<Transform>().position.x;
      //transform.position.Set(newPos.x, newPos.y, newPos.z);
      locked = true;
    }

    if (Mathf.Abs(player.transform.position.y) < lockY)
    {
      newPos.y = player.GetComponent<Transform>().position.y;
      //transform.position.Set(newPos.x, newPos.y, newPos.z);
      locked = true;
    }

    //print(newPos);
    transform.position = newPos;

    if (locked) return;

    newPos.x = player.transform.position.x;
    newPos.y = player.transform.position.y;

    transform.position.Set(newPos.x , newPos.y, newPos.z);
  }
}
