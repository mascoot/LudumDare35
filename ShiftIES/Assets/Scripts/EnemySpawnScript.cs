using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

	// Use this for initialization
  public GameObject enemy1;
  private GameObject GM;
  public int EnemyCount;
  private int MaxEnemyCount;
  private float spawnInterval;
  private float spawnTimer;
  


	void Start () {
    EnemyCount = 0;
    MaxEnemyCount = 5;
    spawnInterval = 2.0f;
    spawnTimer = 0.0f;
    GM = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
    if (GM.GetComponent<GameManagerScript>().IsPaused()) return;
    spawnTimer += Time.deltaTime;

    if(EnemyCount < MaxEnemyCount && spawnTimer > spawnInterval)
    {
      Vector3 spawnLocation = ChooseSpawnSpot();
      Instantiate(enemy1, spawnLocation, Quaternion.identity);
      spawnTimer = 0.0f;
      EnemyCount++;
    }

	}


  Vector3 ChooseSpawnSpot()
  {
    //set up the zone
    Vector3 spawnPos;
    float PosX = Random.value > 0.5f? 20 : -20;
    float PosY = Random.value > 0.5f ? 20 : -20;

    //set up position

    if(Random.value > 0.5f)
    {
      PosX += Random.value *PosX;
      spawnPos = new Vector3(PosX, PosY, 0);
      return spawnPos;
    }

    if(Random.value > 0.5f)
    {
      PosY += Random.value * PosY;
      spawnPos = new Vector3(PosX, PosY, 0);
      return spawnPos;
    }

    spawnPos = new Vector3(PosX, PosY, 0);
    return spawnPos;
  }

  public void KillEnemy()
  {
    EnemyCount--;
  }
}
