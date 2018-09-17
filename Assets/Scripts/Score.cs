using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text currentWave;

    private int score;
    private int highScore;
    private int waves;
    
    private string highScoreKey = "HighScore";

	
	void Start ()
    {
        Initialize();    
	}

    void Update()
    {
        if (highScore < score)
        {
            highScore = score;
        }

        scoreText.text = score.ToString();
        highScoreText.text = highScoreKey + " " + highScore.ToString();
        currentWave.text = "Wave" + " " + waves.ToString();

        if(waves == 11)
        {
            currentWave.text = "Boss";
        }
    }

    public void AddWave(int waveCounter)
    {
        waves = waveCounter; 
    }

    private void Initialize ()
    {
        score = 0;

        highScore = PlayerPrefs.GetInt(highScoreKey, highScore);
    }

    public void AddPoint(int point)
    {
        score += point;
    }

    public void CurrentWave(int wave)
    {
        waves += wave;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        Initialize();
    }
}
