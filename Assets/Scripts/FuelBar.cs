using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuelBar : MonoBehaviour 
{
	Spaceship spaceship;
    Player player;
	public float fuel = 30, maxFuel = 40;
	float moveSpeed;
	Rect fuelBar;
	Texture2D fuelTexture;
	public bool isMoving = true;

	void Start()
	{
		fuelBar = new Rect (Screen.width/ 95, Screen.height * 95/100, Screen.width / 3, Screen.height / 50);
		fuelTexture = new Texture2D (1, 1);
		fuelTexture.SetPixel (0, 0, Color.white);
		fuelTexture.Apply();
	}

	void Awake()
	{
		spaceship = GetComponent<Spaceship>();
        player = GetComponent<Player>();
	}

	void Update ()
	{
		if (isMoving) 
		{
			fuel -= Time.deltaTime;
			if (fuel <= 0)
			{
				fuel = 0f;
				FindObjectOfType<Manager>().GameOver();
				spaceship.Explosion();
				Destroy(gameObject);
			}
            
		}
        if (fuel >= maxFuel)
        {
            fuel = maxFuel;
        } 
	}

	void OnGUI()
	{
		float ratio = fuel / maxFuel;
		float rectWidth = ratio * Screen.width / 3;
		fuelBar.width = rectWidth;
		GUI.DrawTexture (fuelBar, fuelTexture);
	}
}
