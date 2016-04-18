using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour {

	// Use this for initialization
  public GameObject startTexture;
  public GameObject GameOverTexture;
  public GameObject hiScore;
  public GameObject Formation;
  public GameObject Cam;
  public bool pause;
  public bool GameStart;
  public bool GameLost;

	void Start () {
	  pause = true;
    GameStart = true;
    GameLost = false;
    Formation = GameObject.Find("Formation");
    Cam = GameObject.Find("Main Camera");
    Vector3 CamPos = Cam.transform.position;
    CamPos.z = -1;
    startTexture.transform.position = CamPos;
    startTexture.SetActive(true);
    GameOverTexture.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	  if(GameStart)
    {
      //show texture on how to play.
      if(Input.anyKeyDown)
      {
        GameStart = false;
        pause = false;
        startTexture.SetActive(false);
      }
      
    }

    if(GameLost)
    {
      //Show lostTexture;
      Vector3 CamPos = Cam.transform.position;
      CamPos.z = -1;
      GameOverTexture.transform.position = CamPos;
      GameOverTexture.SetActive(true);
      int HS = Formation.GetComponent<FormationScript>().GetTopScore();
      hiScore.GetComponent<Text>().text = HS.ToString();
      hiScore.SetActive(true);

      if (Input.anyKeyDown)
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
	}


  public void SetGameLost()
  {
    GameLost = true;
    pause = true;
  }

  public bool IsPaused()
  {
    return pause;
  }
}
