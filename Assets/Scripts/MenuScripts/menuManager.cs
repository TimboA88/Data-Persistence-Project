using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class menuManager : MonoBehaviour
{
    public static menuManager Instance;
    public int savedScore;
    public string savedName;
    public string currentPlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        infoLoad();
    }

    [System.Serializable]
    class SaveData
    {
        public string savedName;
        public int savedScore;
    }

    public void infoSave()
    {
        SaveData data = new SaveData();
        data.savedName = savedName;
        data.savedScore = savedScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void infoLoad()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedName = data.savedName;
            savedScore = data.savedScore;
        }
    }
}
