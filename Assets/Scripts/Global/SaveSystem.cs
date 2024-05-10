using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private static readonly string FILE_EXTENSION = ".json";

    public static void SaveGameState()
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
        string filePath = SAVE_FOLDER + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + FILE_EXTENSION;
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
}
