using UnityEngine;
using System.Collections;

//We are not inherting anything from MonoBehaviour Class.
public static class GamePrefrences {

    public static string EasyDifficulty   = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty   = "HardDifficulty";

    public static string EasyDifficultyHighScore   = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore   = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore   = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore   = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

//PlayerPrefs Stores and accesses player preferences between game sessions.
    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePrefrences.IsMusicOn, state);
    }

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePrefrences.IsMusicOn);
    }

    public static void SetEasyDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePrefrences.EasyDifficulty, state);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePrefrences.EasyDifficulty);
    }

    public static int GetMediumDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePrefrences.MediumDifficulty);
    }

    public static void SetMediumDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePrefrences.MediumDifficulty, state);
    }

    public static int GetHardDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePrefrences.HardDifficulty);
    }

    public static void SetHardDifficultyState(int state)
    {
        PlayerPrefs.SetInt(GamePrefrences.HardDifficulty, state);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.EasyDifficultyHighScore);
    }

    public static void SetEasyDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.EasyDifficultyHighScore, score);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.MediumDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.MediumDifficultyHighScore, score);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.HardDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.HardDifficultyHighScore, score);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.EasyDifficultyCoinScore);
    }

    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.EasyDifficultyCoinScore, score);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.MediumDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.MediumDifficultyCoinScore, score);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePrefrences.HardDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePrefrences.HardDifficultyCoinScore, score);
    }
}
