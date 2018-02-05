using UnityEngine;
using System.Collections;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
        SetTheDifficulty();
    }

    void SetIntialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
            
    }

    void SetTheDifficulty()
    {
        if(GamePrefrences.GetEasyDifficultyState() == 1)
        {
            SetIntialDifficulty("easy");
        }
        if(GamePrefrences.GetMediumDifficultyState() == 1)
        {
            SetIntialDifficulty("medium");
        }
        if(GamePrefrences.GetHardDifficultyState() == 1)
        {
            SetIntialDifficulty("hard");
        }
    }

/* Using the GamePrefrences to actually store the data we want.
 * And activating and deavtivating the appropriate signs.*/
    public void EasyDifficulty()
    {
        GamePrefrences.SetEasyDifficultyState(1);
        GamePrefrences.SetMediumDifficultyState(0);
        GamePrefrences.SetHardDifficultyState(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty()
    {
        GamePrefrences.SetEasyDifficultyState(0);
        GamePrefrences.SetMediumDifficultyState(1);
        GamePrefrences.SetHardDifficultyState(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePrefrences.SetEasyDifficultyState(0);
        GamePrefrences.SetMediumDifficultyState(0);
        GamePrefrences.SetHardDifficultyState(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
