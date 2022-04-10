using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text BestScore;
    
    public GameObject inputPlayerName;
    protected string m_Text;

    public GameObject needEnterName;



   
    public void NewInputPlayerName(string playerName)
    {

        // add code here to handle when a color is selected
        GameManager.Instance.playerName = playerName;
    }

    private void Start()
    {
        needEnterName.SetActive(false);
        LoadBestPlayer();
    }
   
    public void StartNew()
    {
        string playerName = inputPlayerName.GetComponent<TMP_InputField>().text;
        if (playerName == "")
        {
            needEnterName.SetActive(true); 
        }
        else
        {
           
            SavePlayerName(playerName);
        Debug.Log(playerName);
        SceneManager.LoadScene(1);
        }
    }

   

    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SavePlayerName(string playerName)
    {
        GameManager.Instance.playerName = playerName;
      
        GameManager.Instance.SavePlayerInfo();
    }

    public void LoadBestPlayer()
    {
        GameManager.Instance.LoadPlayerInfo();
        int bestScore = GameManager.Instance.bestScore;
        string bestPlayerName = GameManager.Instance.bestPlayerName;
        
        BestScore.text = "Best score: " + bestPlayerName + ": " + bestScore;
    }


}
