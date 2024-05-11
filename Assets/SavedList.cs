using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SavedList : MonoBehaviour
{
    public Button buttonPrefab;
    public GameObject[] buttonList;
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    void Start()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Debug.LogError("Save directory does not exist: " + SAVE_FOLDER);
            return;
        }

        string[] saveFiles = Directory.GetFiles(SAVE_FOLDER);
        string[] files = SaveSystem.LoadRecentSaveSlots();
        int i = 0;

        foreach (string saveFile in files)
        {
            Debug.Log(saveFile);
            if (!saveFile.EndsWith(".meta"))
            {
                AssignButton(Path.GetFileName(saveFile), i);
                i++;
            }
        }
    }

    void AssignButton(string fileName, int index)
    {

        GameObject buttonObj = buttonList[index];
        if (buttonObj == null)
        {
            Debug.LogError("Button not found: " + index);
            return;
        }

        Button button = buttonObj.GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on object: " + index);
            return;
        }

        // Set button text
        //TextMeshProUGUI[] buttonTexts = button.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

        //foreach (TextMeshProUGUI buttonText in buttonTexts)
        //{
         //   if (buttonText.name == "Name")
        //    {
        //        buttonText.text = GetNameFromFileName(fileName);
      //          buttonText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
      //      }
     //       else if (buttonText.name == "Date")
     //       {
     //           buttonText.text = GetDateFromFileName(fileName);
     //           buttonText.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
     //       }
     //   }

        buttonText.text = GetNameFromFileName(fileName) + "  " + GetDateFromFileName(fileName);
        buttonObj.SetActive(true);

        // Add click listener
        button.onClick.AddListener(() => SaveSystem.LoadGameState(fileName));
    }

    string GetNameFromFileName(string fileName)
    {
        string[] parts = fileName.Split('_');
        if (parts.Length >= 2)
        {
            return parts[0];
        }
        else
        {
            Debug.LogError("Invalid File Name Format: " + fileName);
            return "Invalid File Name Format";
        }
    }

    string GetDateFromFileName(string fileName)
    {
        // Extract date from the file name (assuming the file name format is yyyy-MM-dd-HH-mm-ss.json)
        string[] parts = fileName.Split('-');
        if (parts.Length >= 3)
        {
            return parts[0] + "-" + parts[1] + "-" + parts[2];
        }
        else
        {
            return "Invalid Date";
        }
    }
}
