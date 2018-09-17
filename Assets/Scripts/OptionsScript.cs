using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionsScript : MonoBehaviour 
{
	float hSliderValue = 0.0f;
	Rect pauseMenu;
	Texture2D pauseTexture;

	void OnMouseDown()
	{
		pauseMenu = new Rect (Screen.width / 3, Screen.height / 5, Screen.width / 3, Screen.height / 2);
		pauseTexture = new Texture2D (1, 1);
		pauseTexture.SetPixel (0, 0, Color.blue);
		pauseTexture.Apply ();
	}

	void Update()
	{
		AudioListener.volume = hSliderValue/10.0f;
	}

	void OnGUI()
	{
		GUI.DrawTexture (pauseMenu, pauseTexture);
		hSliderValue = GUI.HorizontalSlider (new Rect (600, 220, 200, 30), hSliderValue, 0.0f, 10.0f);

	}
}
