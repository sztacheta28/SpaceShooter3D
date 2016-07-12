using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 0.1f;
	public float rotSpeed = 180f;

	float shipBoundaryRadius = 0.5f;

	public Texture leftBtn;	
	public Texture rightBtn;

	int factor = 0;

	void Update () {

		// ROTATE the ship.

		// Grab our rotation quaternion
		Quaternion rot = transform.rotation;

		// MOVE the ship.
		Vector3 pos = transform.localPosition;
		 
		Vector3 velocity = new Vector3(factor * maxSpeed * Time.deltaTime, 0, 0);

		pos += rot * velocity;

		if(pos.x > 0.23f) {
			pos.x = 0.23f;
		}
		if(pos.x < -0.23f) {
			pos.x = -0.23f;
		}

		// Finally, update our position!!
		transform.localPosition = pos;
	}

	void OnGUI(){
		factor = 0;

		if (GUI.RepeatButton(new Rect(0, 0.85f*Screen.height, 0.15f*Screen.height, 0.15f*Screen.height), leftBtn, "")){
			factor = -1;
		}

		if (GUI.RepeatButton(new Rect(Screen.width-0.15f*Screen.height, 0.85f*Screen.height, 0.15f*Screen.height, 0.15f*Screen.height), rightBtn, "")){
			factor = 1;
		}
	}
}