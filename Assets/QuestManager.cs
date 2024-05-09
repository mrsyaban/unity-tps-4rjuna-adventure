using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager: MonoBehaviour
{
    public string level;
    public int rewardCompletion;
    public Objective questObjective;
    private void Update()
    {
        if (!IsQuestCompleted()) return;
        // if quest completed
        OnQuestCompleted();
    }

    private void OnQuestCompleted()
    {
        GameStateManager.Instance.AddCoin(rewardCompletion);
        SceneManager.LoadScene("Scenes/GameTest/Level0"+level);
    }

    private bool IsQuestCompleted()
    {
        return questObjective.IsCompleted();
    }
}