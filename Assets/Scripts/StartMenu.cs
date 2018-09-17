using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour 
{
	public Button startText;
	public Button exitText;
    private int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;


	// Use this for initialization
	void Start () 
	{
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}

	public void Exit ()
	{
		Application.Quit ();
	}

	public void OptionsPress ()
	{
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void BackPress ()
	{
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel()
	{
        SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

}
