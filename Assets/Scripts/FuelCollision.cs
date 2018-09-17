using UnityEngine;
using System.Collections;

public class FuelCollision : MonoBehaviour {

	FuelBar fuel;

	void OnTriggerStay(Collider Col)
	{
		GameObject theFuel = GameObject.Find("TheFuel");
		fuel = theFuel.GetComponent<FuelBar> ();
		fuel.fuel += 10;
		Destroy (Col.gameObject);
	}
}
