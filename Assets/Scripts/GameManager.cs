using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// instance
	public static GameManager instance = null;
	public ParticleEmitter introFX;
	public float fxDelay = 10.8f;
	// private variables
	private Transform TFM;

	// added version control for commiting updates

	// added a new comment to test commit
		
	// we need seperate input states for 4 directions
	public enum GameState {
		IDLE,
		MENU,
		GAME,
		PAUSE,
		END
	};
	public GameState gameState = GameState.IDLE;
	
	// define instance in Awake()
	void Awake() {
		// create a handle to this class
		instance = this;	
		// declare your transform (for optimization)
		TFM = transform;
		// manage it across scenes
		DontDestroyOnLoad(TFM.gameObject);
	}

	// Use this for initialization
	void Start () {
		// call our fade Out/In texture screen
		ScreenFadeTexture.CreateScreenFadeTexture(true, true, 6.0f, 9.0f, 6.0f);
		
		// call our StartGXDelay method
		StartCoroutine(StartFXDelay());
	}
	
	IEnumerator StartFXDelay() {
		yield return new WaitForSeconds(fxDelay);
		introFX.emit = false;
	}
}