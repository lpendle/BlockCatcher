using UnityEngine;
using System.Collections;

// SCRIPT FOR PADDLE - MOVEMENTS USE WASD, AD=LEFT/RIGHT, WS=TILT ON 

public class Paddle : MonoBehaviour {
	public float tiltSpeed = 30.0f;
	public float tiltMax = 75.0f;
	public float moveSpeed = 20.0f;
	public float moveMin = -2.5f;
	public float moveMax = 2.5f;
	
	private Transform TFM;
	
	public bool isTilting = false;
	public bool isMoving = false;
	
	// Use this for initialization
	void Start () {
		TFM = transform;
	}
	
	// Update is called once per frame
	void Update () {
		TFM.Rotate(Vector3.up * Input.GetAxis("Vertical") * tiltSpeed *Time.deltaTime, Space.Self);
		
		isTilting = false;
		isMoving = false;
		
		if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0)
		{
			isTilting = true;
			isMoving = true;
		}
		
		if (TFM.eulerAngles.x <= tiltMax) {
			TFM.localEulerAngles = new Vector3(tiltMax, TFM.eulerAngles.y, TFM.eulerAngles.z);
		}

		TFM.Translate(Vector3.right * Input.GetAxis("Horizontal") * 10 * Time.deltaTime, Space.Self);
		TFM.position = new Vector3(TFM.position.x, 0.0f, 0.0f);
		if (TFM.position.x < -2.5f) {
			TFM.position = new Vector3(-2.5f, 0.0f, 0.0f);
		}
		else if (TFM.position.x > 2.5f) {
			TFM.position = new Vector3(2.5f, 0.0f, 0.0f);
		}
	}
}
