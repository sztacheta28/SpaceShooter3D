using UnityEngine;
using System.Collections;
using Vuforia;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;

	float shipBoundaryRadius = 0.5f;

	public int numLives = 4;

	float respawnTimer;

	bool firstTime = true;

	bool flashing;

	float rekord;

	public Texture againBtn;
	
	void Start () {
		rekord = PlayerPrefs.GetFloat("scores");
		Time.timeScale = 1f;
		SpawnPlayer();

        Scores.countScore = true;
	}

	IEnumerator SpawnPlayer() {
		numLives--;
		respawnTimer = 0.5f;
		Bonuses.shootingLevel = 0;

		playerInstance = (GameObject)Instantiate(playerPrefab);
		playerInstance.transform.parent = transform;
		playerInstance.transform.localScale = new Vector3 (0.02f, 0.02f, 0.02f);
		playerInstance.transform.localPosition = new Vector3(0, 0, -0.25f);
		playerInstance.transform.localRotation = Quaternion.Euler (-270f, 0f, 0f);

		if(!firstTime){
			flashing = true;
			playerInstance.GetComponent<Collider>().enabled = false;

			yield return new WaitForSeconds(3);

			flashing = false;
			playerInstance.GetComponent<Collider>().enabled = true;
			playerInstance.GetComponent<Renderer>().enabled = true;
		}
		firstTime = false;
	}

	void Update () {
		if(playerInstance == null && numLives > 0f) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0f) {
				StartCoroutine("SpawnPlayer");
			}
		}

		if(flashing){
			playerInstance.GetComponent<Renderer>().enabled = !playerInstance.GetComponent<Renderer>().enabled;
		}
	}

	void OnGUI() {
		if (DefaultTrackableEventHandler.trackingLost) {
			print(Time.time - DefaultTrackableEventHandler.trackingLostTime);
			if(Time.time - DefaultTrackableEventHandler.trackingLostTime > 5f){
				numLives = 0;
				Destroy(playerInstance);
			}
		}

		if(numLives > 0 || playerInstance != null) {
			GUI.Label( new Rect(0, 0, 100, 50), "Pozostałe życia: " + numLives);
		}
		else {
			GUI.Label( new Rect( Screen.width/2 - 45 , Screen.height/2 - 75, 150, 50), "Przegrałeś!");
			GUI.Label( new Rect( Screen.width/2 - 45 , Screen.height/2 - 25, 150, 50), "Twój wynik: "+Scores.score);
			if(rekord < Scores.score){
				GUI.Label( new Rect( Screen.width/2 - 45 , Screen.height/2 + 25, 150, 50), "Pobiłeś rekord!");
				PlayerPrefs.SetFloat("scores", Scores.score);
			}else{
				GUI.Label( new Rect( Screen.width/2 - 45 , Screen.height/2 + 25, 150, 50), "Rekord to: "+rekord);
			}

            //Time.timeScale = 0f;
            Scores.countScore = false;

			if(GUI.Button( new Rect(Screen.width/2-100 , 0.15f*Screen.height, 200, 0.10f*Screen.height), againBtn, "")){
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
