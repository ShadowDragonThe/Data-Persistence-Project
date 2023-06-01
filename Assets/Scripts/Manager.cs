using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public string Name;
    public string HighName;
    public int HighScore;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public class SaveData
    {
        public string savedHighName;
        public int savedHighScore;
    }
    public void SaveHigh()
    {
        SaveData data = new SaveData();
        data.savedHighName = HighName;
        data.savedHighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }

    public void LoadHigh()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighName = data.savedHighName;
            HighScore = data.savedHighScore;
        }
        
    }
}
