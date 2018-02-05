using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDies;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void Awake()
    {
        MakeSingleton();
        SceneManager.activeSceneChanged += OnLevelWasLoaded1;
        InitializeVariables();
    }

    void Update()
    {
        
    }

//When we change from one scene to another scene OnLevelWasLoaded function is called.
    void OnLevelWasLoaded1(Scene previousScene, Scene newScene)
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            // Rakesh: Not sure why when the game restarts, the values of  
            // the attributes in GameManager.instance object are different 
            // from the values of the individual attributes when I put a 
            // break point and hover over the values. So changing each attribute
            // reference below to GameManager.instance."attribute".
            if (GameManager.instance.gameRestartedAfterPlayerDies)
            {
                GameplayController.instance.SetScore(GameManager.instance.score);
                GameplayController.instance.SetCoinScore(GameManager.instance.coinScore);
                GameplayController.instance.SetLifeScore(GameManager.instance.lifeScore);

                PlayerScore.scoreCount = GameManager.instance.score;
                PlayerScore.coinCount = GameManager.instance.coinScore;
                PlayerScore.lifeCount = GameManager.instance.lifeScore;
            }
            //Rakesh: Modified the below line to fix lives and coin issue. 
            //Correct this later.
            //else if (gameStartedFromMainMenu)
            else
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);
            }

        }

    }

//Initializing the game to make the Easy, Medium, Difficult check signs available.
    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePrefrences.SetEasyDifficultyState(0);
            GamePrefrences.SetEasyDifficultyCoinScore(0);
            GamePrefrences.SetEasyDifficultyHighScore(0);

            GamePrefrences.SetMediumDifficultyState(1);
            GamePrefrences.SetMediumDifficultyCoinScore(0);
            GamePrefrences.SetMediumDifficultyHighScore(0);

            GamePrefrences.SetHardDifficultyState(0);
            GamePrefrences.SetHardDifficultyCoinScore(0);
            GamePrefrences.SetHardDifficultyHighScore(0);

            GamePrefrences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }

//Singleton creates gameObject if there are none & destroys them if they are duplicates.
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject); //destroys the duplicate
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

/* 1. Checking if the life of the player is less than 2 or not. And saving the scores 
 *    if the player Restarts the game.
 * 2. If the player makes the highesh score in that particaluar game then the 
 *    score and coinScore become the highest score respectively.  */

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if(lifeScore < 0)
        {
            if(GamePrefrences.GetEasyDifficultyState() == 1)
            {
                int highScore = GamePrefrences.GetEasyDifficultyHighScore();
                int coinHighScore = GamePrefrences.GetEasyDifficultyCoinScore();

                if(highScore < score)
                    GamePrefrences.SetEasyDifficultyHighScore(score);

                if (coinHighScore < coinScore)
                    GamePrefrences.SetEasyDifficultyCoinScore(coinScore);
            }

            if (GamePrefrences.GetMediumDifficultyState() == 1)
            {
                int highScore = GamePrefrences.GetMediumDifficultyHighScore();
                int coinHighScore = GamePrefrences.GetMediumDifficultyCoinScore();

                if (highScore < score)
                    GamePrefrences.SetMediumDifficultyHighScore(score);

                if (coinHighScore < coinScore)
                    GamePrefrences.SetMediumDifficultyCoinScore(coinScore);
            }

            if (GamePrefrences.GetHardDifficultyState() == 1)
            {
                int highScore = GamePrefrences.GetHardDifficultyHighScore();
                int coinHighScore = GamePrefrences.GetHardDifficultyCoinScore();

                if (highScore < score)
                    GamePrefrences.SetHardDifficultyHighScore(score);

                if (coinHighScore < coinScore)
                    GamePrefrences.SetHardDifficultyCoinScore(coinScore);
            }

            gameRestartedAfterPlayerDies = false;
            gameStartedFromMainMenu = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else 
        {
            this.score = score;
            this.lifeScore = lifeScore;
            this.coinScore = coinScore;

            gameRestartedAfterPlayerDies = true;
            gameStartedFromMainMenu = false;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }
    
}
