using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    FuelBar fuelBar;

    public Canvas optionsMenu;
    public Button exitText;
    public Button optionsText;
    public bool endGame;
    public GameObject player;
    public AudioClip merryChristmas;

    public Text win;

    private GameObject title;

    private GameObject pauseMenu;

    private GameObject bgm;

    private AudioSource BGM;

    // CHEAT
    private Bullet bullet;

    private GameObject playerbullet;

    private bool pauseGame = false;

    void Start()
    {
        title = GameObject.Find("Title");
        pauseMenu = GameObject.Find("Pause");
        bgm = GameObject.Find("bgm");
        BGM = bgm.GetComponent<AudioSource>();
        playerbullet = GameObject.Find("PlayerBullet");
        title.SetActive(false);
        pauseMenu.SetActive(false);
        GameStart();
        
        fuelBar = GetComponent<FuelBar>();
    }

    void Update()
    {
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.X))
        {
            GameStart();
            title.SetActive(false);
        }
        if (title.activeSelf == false && Input.GetKeyDown(KeyCode.Escape) && IsPlaying() == true)
        {
            if(pauseGame == false)
            {
                Time.timeScale = 0;
                pauseGame = true;
                pauseMenu.SetActive(true);
                BGM.Pause();
            }
            else
            {
                Time.timeScale = 1;
                pauseGame = false;
                pauseMenu.SetActive(false);
                optionsMenu.enabled = false;
                optionsText.enabled = true;
                exitText.enabled = true;
                BGM.UnPause();
            }
        }
        else if (title.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        if(title.activeSelf == false && endGame == true)
        {
            FindObjectOfType<FuelBar>().isMoving = false;
            win.enabled = true;
            BGM.clip = merryChristmas;
        }
    }
    
    void GameStart()
    {
        // title.SetActive(false);
        Instantiate(player, player.transform.position, transform.rotation);
    }
    public void GameOver()
    {
        FindObjectOfType<Score>().Save();
        title.SetActive(true);
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public bool IsPlaying()
    {
        return title.activeSelf == false;
    }
}
