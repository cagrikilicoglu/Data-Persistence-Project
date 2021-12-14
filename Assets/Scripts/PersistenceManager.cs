using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string nameString;
    public string highScoreUser;
    public int highScore;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadHighScore();
    }
    void Update()
    {
        
    }

    class HighScore
    {
        public int highScorePoint;
        public string highScoreUsername;
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            HighScore highScoreData = JsonUtility.FromJson<HighScore>(json);
            highScore = highScoreData.highScorePoint;
            highScoreUser = highScoreData.highScoreUsername;
        }
    }

    public void SaveHighScore()
    {
        HighScore highScoreData = new HighScore();
        highScoreData.highScorePoint = highScore;
        highScoreData.highScoreUsername = highScoreUser;
        string json = JsonUtility.ToJson(highScoreData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
