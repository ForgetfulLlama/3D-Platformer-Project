using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public float best_time;
    public string best_str;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    class SaveData
    {
        public float bestTime;
        public string bestStr;
    }

    public void UpdateBestTime(float best)
    {
        best_time = best;
        float minutes = Mathf.FloorToInt(best / 60);
        float seconds = Mathf.FloorToInt(best % 60);
        best_str = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.bestTime = best_time;
        data.bestStr = best_str;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            best_time = data.bestTime;
            best_str = data.bestStr;
        }
    }
}
