using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO;

public class UIHandler : MonoBehaviour
{
    public TMPro.TMP_InputField nameInput;
    public TMPro.TMP_Text Score;

    private void Start()
    {
        Manager.instance.LoadHigh();
        string path = Application.persistentDataPath + "/SaveFile.json";
        if (File.Exists(path)) {
            Score.text = "Best Score : " + Manager.instance.HighName + " : "+ Manager.instance.HighScore;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
       EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SaveName()
    {
        Manager.instance.Name = nameInput.text;
    }
}
