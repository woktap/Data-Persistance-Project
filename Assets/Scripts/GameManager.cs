using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int playerScore;

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
    public void NewPlayerName(string PlayerName)
    {
       // MainManager.Instantiate.PlayerName = PlayerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerScore;
    }
    
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerScore = playerScore;

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
        }
    }

}
