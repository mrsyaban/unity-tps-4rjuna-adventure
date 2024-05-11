
using System;
using TMPro;
using UnityEngine;

public class Objective02 : Objective
{
    [SerializeField] public TextMeshProUGUI KrocoUI;
    [SerializeField] public TextMeshProUGUI KepalaKrocoUI;
    [SerializeField] public TextMeshProUGUI JendralUI;

    private int curKrocoKilled = GameStateManager.Instance.krocoKill;
    private int curKepalaKrocoKilled = GameStateManager.Instance.kepalaKrocoKill;
    private int curJendralKilled = GameStateManager.Instance.jendralKill;
    
    public override bool IsCompleted()
    {
        int krocoTreshold = 10;
        int kepalaKrocoTreshold = 5;
        int jendralTreshold = 3;
    
        int krocoKilled = GameStateManager.Instance.krocoKill - curKrocoKilled;
        KrocoUI.SetText("Kroco: " +krocoKilled.ToString()+"/"+krocoTreshold);
        
        int kepalaKrocoKilled = GameStateManager.Instance.krocoKill - curKepalaKrocoKilled;
        KepalaKrocoUI.SetText("Kepala Kroco: "+kepalaKrocoKilled.ToString()+"/"+kepalaKrocoTreshold);
        
        int jendralKilled = GameStateManager.Instance.krocoKill - curJendralKilled;
        JendralUI.SetText("Jendral: "+krocoKilled.ToString()+"/"+jendralTreshold);

        if (krocoKilled >= krocoTreshold && kepalaKrocoKilled >= kepalaKrocoTreshold && jendralKilled >= jendralTreshold)
        {
            Debug.Log(GameStateManager.Instance.krocoKill);
            Debug.Log(krocoTreshold);
            return true;
        }
        return false;
    }
}
