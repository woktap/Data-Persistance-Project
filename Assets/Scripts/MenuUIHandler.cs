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
   // public ColorPicker ColorPicker;
    public GameObject inputPlayerName;
    protected string m_Text; 




    public void NewInputPlayerName(string playerName)
    {

        // add code here to handle when a color is selected
    }

    private void Start()
    {
        


        //inputPlayerName.name = GetComponent<InputField>().text;
      // ColorPicker.Init();
      // this will call the NewColorSelected function when the color picker has a color button clicked
      // ColorPicker.onColorChanged += NewColorSelected;
    }
    private void Update()
    {
       
        
    }
    public void StartNew()
    {
        string playerName = inputPlayerName.GetComponent<TMP_InputField>().text;
        Debug.Log(playerName);
        SceneManager.LoadScene(1);
    }

    public void Exite()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
