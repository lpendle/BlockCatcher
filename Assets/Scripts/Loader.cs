using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour 
{
	// fields
	public Texture2D logoScreen;
	public Texture2D titleScreen;
	public Texture2D creditScreen;
	
	public bool skipToMenu = false;
	public bool skipToGame = false;
	
	// Use this for initialization
	IEnumerator Start () 
	{
		if (skipToMenu)
		{
			Application.LoadLevel("SceneMenu");
		}
		
		if (skipToGame)
		{
			Application.LoadLevel("SceneGame");
		}
		
		guiTexture.texture = logoScreen;
		
		yield return new WaitForSeconds(9);
		
		guiTexture.texture = titleScreen;
		
		yield return new WaitForSeconds(9);
		
		guiTexture.texture = creditScreen;
		
		yield return new WaitForSeconds(9);
			
		Application.LoadLevel("Menu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
