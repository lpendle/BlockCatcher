using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
{
	// private variables
	public Transform paddleTFM;
	private Paddle paddle;
	public Transform parentTFM;
	private Transform TFM;
	
	// called before Start()
	void Awake()
	{
		// cache transform
		TFM = transform;
	}
	
	// Use this for initialization
	void Start () 
	{
		paddle = GameObject.Find ("PaddleMain").GetComponent<Paddle>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		parentTFM = null;
		TFM.parent = null;
		
		TFM.GetComponent<Rigidbody>().useGravity = true;
		TFM.GetComponent<Rigidbody>().isKinematic = false;
		
		if (paddle.isTilting || paddle.isMoving)
		{
			parentTFM = paddleTFM;
			TFM.parent = parentTFM;
			TFM.GetComponent<Rigidbody>().useGravity = false;
			TFM.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
