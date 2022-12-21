using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance { get; set; }
    public string PlayerName { get; set; }
    public string HighScorePlayerName { get; set; }
    public int HighScore { get; set; }

    string savePath;
    
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        savePath = Application.persistentDataPath + "/highscore.json";

        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public string HighScorePlayerName;
        public int Score;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.PlayerName = this.PlayerName;
        data.HighScorePlayerName = this.HighScorePlayerName;
        data.Score = this.HighScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public void LoadPlayerData()
    {
        string path = savePath;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            this.PlayerName = data.PlayerName;
            this.HighScorePlayerName = data.HighScorePlayerName;
            this.HighScore = data.Score;
        }
    }
}
