using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	public static float score;
    public static bool countScore;

	void Start(){
        Scores.score = 0;
        Scores.countScore = false;
    }

	void Update (){
        if (!Vuforia.DefaultTrackableEventHandler.trackingLost && countScore) {
            score += Time.deltaTime;
        }
	}

	void OnGUI(){
		GUI.skin.label.fontSize = 17;
		GUI.Label(new Rect(0.8f*Screen.width, 0f, 0.2f*Screen.width, 0.1f*Screen.height), "Dystans: "+score.ToString("F2"));
	}
}
