using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerSettingManager : MonoBehaviour
{
    public static PlayerSettingManager Instance;

    public string userName;
    public PlayerHighscoreData highScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Serializable]
    public class PlayerHighscoreData
    {
        public string userName;
        public int score;
    }

    public void SaveHighscore(int score)
    {
        PlayerHighscoreData playerHighscore = new PlayerHighscoreData();
        playerHighscore.userName = userName;
        playerHighscore.score = score;
        string jsonData = JsonUtility.ToJson(playerHighscore);
        File.WriteAllText(Application.persistentDataPath + "/playerSetting.json", jsonData);
        highScore = playerHighscore;
    }

    public void LoadHighScore()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/playerSetting.json");
        PlayerHighscoreData playerHighscore = JsonUtility.FromJson<PlayerHighscoreData>(jsonData);
        highScore = playerHighscore;
    }

    public string GetHighScoreMessage()
    {
        return $"Highscore {highScore.userName} : {highScore.score}";
    }
}
