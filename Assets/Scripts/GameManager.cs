using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int playerScore;
    public string bestPlayerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerInfo();
    }

    private void Start()
    {
      //  PlayerName.

      //  if (MainManager.Instantiate != null)
        {

        }
    }
    
    /* public void GetPlayerInfo(string playerName, int playerScore, string bestPlayerName, int bestScore)
    {
       GameManager.Instance.playerName = playerName;
        Debug.Log(playerName);
        GameManager.Instance.playerScore = playerScore;
        Debug.Log(playerScore);
        GameManager.Instance.bestPlayerName = bestPlayerName;
        Debug.Log(bestPlayerName);
        GameManager.Instance.bestScore = bestScore;
        Debug.Log(bestScore);
    }*/
    
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
        public string bestPlayerName;
        public int bestScore;
    }
    
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerScore = playerScore;
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
     
    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            playerScore = data.playerScore;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }

}
