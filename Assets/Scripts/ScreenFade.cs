using UnityEngine;
using System.Collections;

// Desc: Handles 4 types of screen fades
			// 1. FadeOut()   - A single instance of fading out from black to transparent
			// 2. FadeIn()    - A single instance of fading in to black from transparent
			// 3. FadeInOut() - A multi instance, fades in from transparent to black, then out from black to transparent
			// 4. FadeOutIn() - A multi instance, fades out from black to tansparent, then in from transparent to black

public class ScreenFade : MonoBehaviour {
	// fields
	private float fadeTimeIn = 0.0f;      // amount of time to fade In
	private float fadeTimeOut = 0.0f;     // amount of time to fade Out
	private float fadeTimeBetween = 0.0f; // amount of delay between FadeInOut or FadeOutIn
	private float fadeRate = 0.0f;        // the rate at which we are fading        
	private float fadeIndex = 0.0f;       //  our increment index to track amount of time passed
	
	// fields for Color.Lerp 
	private Color curTextureColor;        // stores our current GUITexture color
	private Color newTextureColor;        // stores our desired GUITexture color (only considers the alpha of the color)
	
	private GUITexture cGUITexture;       // stores our GUITexture component
	
	//[HideInInspector] 
	public bool fadeDone = false;
	
	// Use this for initialization
	// Desc: Called from ScreenfadeTexture - ScreenfadeTexture dynamically creates a texture specificaly for screen fades 
	public void StartGUITextureFade(bool fadeIn, bool fadeOut, float timeIn, float timeBetween, float timeOut) {
		// set our time fields based on what was passed as parameters
		fadeTimeIn = timeIn;
		fadeTimeOut = timeOut;
		fadeTimeBetween = timeBetween; 
		
		cGUITexture = GetComponent<GUITexture>();
		
		// assign our current and wanted texture colors
		curTextureColor = cGUITexture.color;
		newTextureColor = new Color(curTextureColor.r, curTextureColor.g, curTextureColor.b, 0.0f);
		
		// single fade in
		if (fadeIn == true && fadeOut == false) {
			// call our FadeIn
			StartCoroutine(FadeIn());
		} 	
		
		// single fade out
		if (fadeIn == false && fadeOut == true) {
			// call our FadeOut
			StartCoroutine(FadeOut());	
		}
		
		// fade in, pause, then fade out
		if (fadeIn == true && fadeOut == true) {
			// call our fadeOut and fadeIn
			StartCoroutine(FadeOutIn());	
		}
		
		// fade out, pause then fade in
		if (fadeIn == false && fadeOut == false) {
			// call our fadeIn and fadeOut	
			StartCoroutine(FadeInOut());
		}
	}
	
	IEnumerator FadeIn() {
		yield return StartCoroutine(FadeGUITextureIn());
		
		fadeDone = true;
	}
	
	IEnumerator FadeOut() {
		yield return StartCoroutine(FadeGUITextureOut());
		
		fadeDone = true;	
	}
	
	IEnumerator FadeOutIn() {
		yield return StartCoroutine(FadeGUITextureOut());
		
		yield return new WaitForSeconds(fadeTimeBetween);
		
		yield return StartCoroutine(FadeGUITextureIn());
		
		fadeDone = true;	
	}
	
	IEnumerator FadeInOut() {
		yield return StartCoroutine(FadeGUITextureIn());
		
		yield return new WaitForSeconds(fadeTimeBetween);
		
		yield return StartCoroutine(FadeGUITextureOut());
		
		fadeDone = true;			
	}
	
	public IEnumerator FadeGUITextureIn() {
		// make sure our fadeTime is 0
		fadeRate = 0.0f;
		// make sure our index is 0
		fadeIndex = 0.0f;
		// set our fade delay time
		fadeRate = 1.0f / fadeTimeIn;
		// loop and fade our texture
		while(fadeIndex < 1.0f) {
			fadeIndex += Time.deltaTime * fadeRate;
			cGUITexture.color = Color.Lerp(newTextureColor, curTextureColor, fadeIndex);
			yield return 0;
		}
	}

	public IEnumerator FadeGUITextureOut() {
		// make sure our fadeTime is 0
		fadeRate = 0.0f;
		// make sure our index is 0
		fadeIndex = 0.0f;
		// set our fade delay time
		fadeRate = 1.0f / fadeTimeOut;
		// loop and fade our texture
		while(fadeIndex < 1.0f) {
			fadeIndex += Time.deltaTime * fadeRate;
			cGUITexture.color = Color.Lerp(curTextureColor, newTextureColor, fadeIndex);
			yield return 0;
		}
	}
}