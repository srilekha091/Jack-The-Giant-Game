using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

    // Use this for initialization
    void Start () {
        SetScoreBasedOnDifficulity();

    }

//Passing the score and coinScore and setting that to be Text.    
    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

/* If we select EasyDifficultyState then we are going to preview 
 * HighScore and CoinScore of EasyDifficultyState.
 * Similarly we are doing for MediumDifficulty and HardDifficulty. */
    void SetScoreBasedOnDifficulity()
    {
        if(GamePrefrences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePrefrences.GetEasyDifficultyHighScore(),
                GamePrefrences.GetEasyDifficultyCoinScore());
        }
        if(GamePrefrences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePrefrences.GetMediumDifficultyHighScore(), 
                GamePrefrences.GetMediumDifficultyCoinScore());
        }
        if(GamePrefrences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePrefrences.GetHardDifficultyHighScore(),
                GamePrefrences.GetHardDifficultyCoinScore());
        }
    }

	public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
