using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    // Use this for initialization
//Time.timeScale = 0 stops everything like the animations, gameplay.
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

   IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
      Application.LoadLevel("MainMenu");
   //     SceneFader.instance.LoadLevel("MainMenu"); 
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }

    IEnumerator  PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
      Application.LoadLevel("GamePlay");
 //       SceneFader.instance.LoadLevel("GamePlay");
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    /*Each time we set the timeScale to 0 we need again set it 
    * back to timeScale 1. If we dont set it back it will affect the animations.
    * Pausing the panel when the player clicks on Pause button*/

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

/*Pauses the game for 1sec and then restarts the game.*/ 
    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        pausePanel.SetActive(false);
    }

/*Quits the game for 1ec and later loads the Main Menu*/
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
}
