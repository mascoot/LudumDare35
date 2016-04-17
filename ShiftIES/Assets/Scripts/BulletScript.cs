using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

  public float lifetime = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    lifetime -= Time.deltaTime;
    if (lifetime <= 0.0f) Destroy(this.gameObject);
	}
}
