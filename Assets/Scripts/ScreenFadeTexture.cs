using UnityEngine;
using System.Collections;

// Desc: Dyanmically create a GUITexture gameobject to use as a screen fader
//       Call CreateScreenFadeTexture() to build at runtime a screen fadeer 
//       GUITexture gameobject and based on the arguments passed, you can 
//       decide what type of screen fade object you need.
//       Exe. ScreenFadeTexture.CreateScreenFadeTexture(true, true, 6.0f, 6.0f, 6.0f);
//            will dynamically create at run time a GUITexture gameobject, and will
//            invoke the method StartGUITextureFade(true, true, 6.0f, 6.0f, 6.0f);
//            which will fade the screen out from black, then wait, and back to black 

public class ScreenFadeTexture : MonoBehaviour {
  // our static screen fade object creator
	public static void CreateScreenFadeTexture(bool fadeIn, bool fadeOut, float timeIn, float timeBetween, float timeOut) {
		// create an empty gameobject
		GameObject newObject = new GameObject("ScreenFade");
		// zer out position
		newObject.transform.position = new Vector3(0,0,1);
		// add our Screenfade script (for fading)
		ScreenFade screenFade = newObject.AddComponent<ScreenFade>();
		
		// add a GUITexture Component
		GUITexture newGUITexture = newObject.AddComponent<GUITexture>();	
		newGUITexture.pixelInset = new Rect(0,0,Screen.width, Screen.height);
		newGUITexture.color = new Color(0,0,0,1);
				
		// create a dynamic Texture2D
		Texture2D newTexture = new Texture2D(1,1);
		newTexture.SetPixel(0,0,Color.black);
		newTexture.Apply();
		newTexture.name = "ScreenCover";
					
		// now build our GUITexture textures property
		newGUITexture.texture = newTexture;
		
		// call our screen fader method
		screenFade.StartGUITextureFade(fadeIn, fadeOut, timeIn, timeBetween, timeOut);
	}	
}