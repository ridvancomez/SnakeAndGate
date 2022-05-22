using System;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreManagement;
    
    public int Score;

    private void Awake()
    {
        if(ScoreManagement != null)
        {
            Destroy(gameObject);
            return;
        }
        ScoreManagement = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class CheckScore
    {
        public string HighScore;
    }

    public void SaveScore()
    {
        CheckScore highScore = new CheckScore();
        highScore.HighScore = Score.ToString();

        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            CheckScore score = JsonUtility.FromJson<CheckScore>(json);

            Score = Convert.ToInt32(score.HighScore);
        }
        else
        {
            SaveScore();
        }
    }
}
