using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	// Use this for initialization
  private int EnemyCount;
  private int MaxEnemyCount;
  private float spawnInterval;
  private float spawnTimer;
  


	void Start () {
    EnemyCount = 0;
    MaxEnemyCount = 5;
    spawnInterval = 3.0f;
    spawnTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
    spawnTimer += Time.deltaTime;

    if(spawnTimer > spawnInterval)
    {
      ChooseSpawnSpot();

    }
	}


  void ChooseSpawnSpot()
  {

  }

  void ChooseMoveDirection()
  {


  }


}
