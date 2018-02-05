using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    [SerializeField]
    public Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    // Use this for initialization
    void Start()
    {
        CheckToPlayMusic();
    }

    public void CheckToPlayMusic()
    {
        if(GamePrefrences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];            
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }	
    
    public void StartGame()
    {
        //Rakesh: Commenting the below line to avoid error for now. Fix this.
        //GameManager.instance.gameStartedFromMainMenu = true;
        Application.LoadLevel("GamePlay");
    }

    public void HighScoreMenu() 
    {
        Application.LoadLevel("HighscoreScene");
    }

    public void OptionsMenu()
    {
        Application.LoadLevel("OptionsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if(GamePrefrences.GetMusicState() == 0)
        {
            GamePrefrences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        }
        else if(GamePrefrences.GetMusicState() == 1) 
        {
            GamePrefrences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }

}
