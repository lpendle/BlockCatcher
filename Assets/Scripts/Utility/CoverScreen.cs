using UnityEngine;
using System.Collections;

public class CoverScreen : MonoBehaviour 
{
	// Use this for initialization
	IEnumerator Start () 
	{
		guiTexture.enabled = true;
		
		Fade.use.Alpha<GUITexture>(guiTexture, 1.0f, 0.0f, 4f, Fade.EaseType.Out);	
		yield return new WaitForSeconds(4);
		
		Fade.use.Alpha<GUITexture>(guiTexture, 0.0f, 1.0f, 4f, Fade.EaseType.In);
		yield return new WaitForSeconds(5);
		
		Fade.use.Alpha<GUITexture>(guiTexture, 1.0f, 0.0f, 4f, Fade.EaseType.Out);	
		yield return new WaitForSeconds(4);
		
		Fade.use.Alpha<GUITexture>(guiTexture, 0.0f, 1.0f, 4f, Fade.EaseType.In);
		yield return new WaitForSeconds(5);
		
		Fade.use.Alpha<GUITexture>(guiTexture, 1.0f, 0.0f, 4f, Fade.EaseType.Out);	
		yield return new WaitForSeconds(4);
		
		Fade.use.Alpha<GUITexture>(guiTexture, 0.0f, 1.0f, 4f, Fade.EaseType.In);
		yield return new WaitForSeconds(5);
		
		guiTexture.enabled = false;
	}
}
