using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Linq;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private static readonly string FILE_EXTENSION = ".json";

    public static void SaveGameState(string name)
    {
        // Create the save directory if it doesn't exist
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
        GameStateManager.Instance.UpdateLevelName(SceneManager.GetActiveScene().name);
        // Convert the GameStateManager data to JSON
        string json = JsonUtility.ToJson(GameStateManager.Instance);

        // Save the JSON data to a file
        string filePath = SAVE_FOLDER + name + "_" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + FILE_EXTENSION;
        File.WriteAllText(filePath, json);

        Debug.Log("Game state saved to: " + filePath);
    }

    public static void LoadGameState(string fileName)
    {
        // Load the JSON data from the file
        string filePath = SAVE_FOLDER + fileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // Convert the JSON data back to GameStateManager object
            JsonUtility.FromJsonOverwrite(json, GameStateManager.Instance);
            GameStateManager.Instance.loadSpeed = true;
            GameStateManager.Instance.loadHealth = true;
            SceneManager.LoadScene(GameStateManager.Instance.levelName);
            Debug.Log("Game state loaded from: " + filePath);
        }
        else
        {
            Debug.LogWarning("No save file found at: " + filePath);
        }
    }

    public static string[] LoadRecentSaveSlots()
    {
        string[] files = Directory.GetFiles(SAVE_FOLDER)
                            .Where(file => IsSaveFile(file))
                            .OrderByDescending(file => GetDateTimeFromFileName(file))
                            .Take(3)
                            .ToArray();

        return files;
    }

    private static bool IsSaveFile(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        return fileName.EndsWith(".json") && fileName.Split("_").Length == 2;
    }

    private static DateTime GetDateTimeFromFileName(string fileName)
    {
        string[] parts = fileName.Split('_');
        string dateTimeString = Path.GetFileNameWithoutExtension(parts[1]);
        return DateTime.ParseExact(dateTimeString, "yyyy-MM-dd-HH-mm-ss", null);
    }
}
