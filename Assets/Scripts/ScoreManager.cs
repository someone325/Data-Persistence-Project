using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private string[] Scores = new string[5];
    private string[] Names = new string[5];
    private string player_name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable] public class SaveData
    {
        public string[] Scores = new string[5];
        public string[] Names = new string[5];
    }
    public void SaveScores()
    {
        SaveData data = new SaveData();
        data.Scores = Scores;
        data.Names = Names;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }
    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Scores = data.Scores;
            Names = data.Names;
        }
    }
    public void Name(string entered_name)
    {
        if (entered_name == "") player_name = "(no name)";
        else player_name = entered_name;
    }
    public void AddScore(int score)
    {
        for(int i = 0; i < 5; i++)
        {
            int board_score;
            if (Scores[i] == null || Scores[i] == "") board_score = 0;
            else board_score = int.Parse(Scores[i]);
            if (board_score < score)
            {
                string temp_name = Names[i];
                string temp_score = Scores[i];
                Names[i] = player_name;
                Scores[i] = score.ToString();
                i++;
                while (i < 5)
                {
                    string temp = Names[i];
                    Names[i] = temp_name;
                    temp_name = temp;
                    temp = Scores[i];
                    Scores[i] = temp_score;
                    temp_score = temp;
                    i++;
                }
                return;
            }
        }
    }
    public string HighScore()
    {
        if (Names[0] == null || Names[0] == "") return "Nobody";
        return Names[0] + ": " + Scores[0];
    }
    public string ScoreTable()
    {
        if (Names[0] == null || Names[0] == "") return "No Scores, Go play!";
        string scoretable = "";
        for(int i = 0; i < 5; i++)
        {
            if(Names[i] != null && Names[i] != "")
            scoretable += Names[i] + ": " + Scores[i] + "\n";
        }
        return scoretable;
    }
}
