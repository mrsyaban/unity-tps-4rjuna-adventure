using System;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsManager : MonoBehaviour
{
    public GameObject statisticsRows;
    public GameObject[] rows;
    private static readonly string SAVE_FOLDER = "/Saves/";

    private void Start()
    {
        //var entries = statisticsRows.GetComponent<RectTransform>();
        //Debug.Log(entries.Length);
        //Debug.Log(entries.ToString());
        //var childEntries = entries.GetComponents<RectTransform>();
        string[] fileNames = SaveSystem.LoadRecentSaveSlots();

        for (var i = 0; i < fileNames.Length; i++)
        {
            //Debug.Log(rows[i].name);
            string filePath = fileNames[i];
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, GameStateManager.Instance);
            var entryValues = rows[i].GetComponentsInChildren<TMP_Text>();
            entryValues[0].text = GameStateManager.Instance.playerName;
            entryValues[1].text = (GameStateManager.Instance.onHitTarget / (GameStateManager.Instance.bulletShot != 0 ? GameStateManager.Instance.bulletShot : 1)).ToString();
            entryValues[2].text = GameStateManager.Instance.distance.ToString();
            entryValues[3].text = GameStateManager.Instance.lifetime.ToString();
            entryValues[4].text = GameStateManager.Instance.kepalaKrocoKill.ToString();
            entryValues[5].text = GameStateManager.Instance.jendralKill.ToString();
            entryValues[6].text = GameStateManager.Instance.krocoKill.ToString();
        }
    }
}