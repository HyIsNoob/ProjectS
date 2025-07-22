using UnityEngine;
using System.IO;

namespace ProjectS
{
    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public float playtime;
        public string currentScene;
        public Vector3 playerPosition;
        public int currentChapter;
        public bool[] storyFlags;
        public string saveDate;
        
        public SaveData()
        {
            playerName = "Player";
            playtime = 0f;
            currentScene = "GameplayScene";
            playerPosition = Vector3.zero;
            currentChapter = 1;
            storyFlags = new bool[50]; // 50 story flags
            saveDate = System.DateTime.Now.ToString();
        }
    }
    
    public static class SaveSystem
    {
        private static string SavePath => Path.Combine(Application.persistentDataPath, "projectS_save.json");
        
        public static void SaveGame(SaveData data)
        {
            try
            {
                string json = JsonUtility.ToJson(data, true);
                File.WriteAllText(SavePath, json);
                Debug.Log("Game saved successfully to: " + SavePath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to save game: " + e.Message);
            }
        }
        
        public static SaveData LoadGame()
        {
            try
            {
                if (File.Exists(SavePath))
                {
                    string json = File.ReadAllText(SavePath);
                    SaveData data = JsonUtility.FromJson<SaveData>(json);
                    Debug.Log("Game loaded successfully from: " + SavePath);
                    return data;
                }
                else
                {
                    Debug.Log("Save file not found, creating new save data");
                    return new SaveData();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load game: " + e.Message);
                return new SaveData();
            }
        }
        
        public static bool HasSaveFile()
        {
            return File.Exists(SavePath);
        }
        
        public static void DeleteSaveFile()
        {
            try
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                    Debug.Log("Save file deleted");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to delete save file: " + e.Message);
            }
        }
        
        public static string GetSaveInfo()
        {
            if (HasSaveFile())
            {
                SaveData data = LoadGame();
                return $"Chapter {data.currentChapter} - {System.TimeSpan.FromSeconds(data.playtime):hh\\:mm\\:ss} - {data.saveDate}";
            }
            return "No save file found";
        }
    }
}
