using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager: MonoBehaviour
{
    public int level;
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
        string nextScene = "Scenes/Cutscene0" + (level + 1).ToString();
        if (level == 3)
        {
             nextScene = "Scenes/ShopCutscene";
        } else if (level == 4)
        {
            nextScene = "Scenes/CutsceneEnding";
        }
        GameStateManager.Instance.AddCoin(rewardCompletion);
        NextScene.Next(nextScene);
    }

    private bool IsQuestCompleted()
    {
        return questObjective.IsCompleted();
    }
}