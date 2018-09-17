using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class VolumeLevel : MonoBehaviour 
{
	public AudioMixer masterMixer;

	public void SetMasterLevel(float MasterLevel)
	{
		masterMixer.SetFloat ("MasterVol", MasterLevel);
	}
}
