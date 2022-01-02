using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    
    public static DataSaver Instance;

    public string _playerName;
    public string _topScoreName;
    public int _topScore;
    public string _topScoreText;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public string _playerName;
        public string _topScoreName;
        public int _topScore;
        public string _topScoreText;
    }

    public void SaveInfo()
    {
        if (_topScore != 0)
        {
            _topScoreText = "Top Score: " + _topScoreName + " (" + _topScore + ")";
        }

        SaveData data = new SaveData();
        
        data._playerName = _playerName;
        data._topScoreName = _topScoreName;
        data._topScore = _topScore;
        data._topScoreText = _topScoreText;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            _playerName = data._playerName;
            _topScoreName = data._topScoreName;
            _topScore = data._topScore;

            if(_topScore != 0)
            {
                _topScoreText = data._topScoreText;
            }
        }
    }

}
