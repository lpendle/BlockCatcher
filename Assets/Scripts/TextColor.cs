using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class TextColor : MonoBehaviour {
	// public color picker
	public Color txtColor;
	
	private GUIText txtMat;

	// Use this for initialization
	void Start () {
		txtMat = GetComponent<GUIText>();
		txtMat.material.color = txtColor;
	}
}
