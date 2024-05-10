using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavedList : MonoBehaviour
{
    public Button buttonPrefab;
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    void Start()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Debug.LogError("Save directory does not exist: " + SAVE_FOLDER);
            return;
        }

        string[] saveFiles = Directory.GetFiles(SAVE_FOLDER);

        foreach (string saveFile in saveFiles)
        {
            Debug.Log(saveFile);
            if (!saveFile.EndsWith(".meta"))
            {
                CreateButton(Path.GetFileName(saveFile));
            }
        }
    }

    void CreateButton(string fileName)
    {
        Button newButton = Instantiate(buttonPrefab, transform);
        newButton.transform.localScale = new Vector3(2f, 2f, 2f); 

        TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
            buttonText.text = fileName;
        }
        else
        {
            Debug.LogError("No TextMeshProUGUI component found in the button prefab's children.");
        }

        newButton.onClick.AddListener(() => SaveSystem.LoadGameState(GameStateManager.Instance, fileName));
    }
}
