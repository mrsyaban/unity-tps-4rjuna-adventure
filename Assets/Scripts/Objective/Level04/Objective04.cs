using TMPro;
using UnityEngine;

public class Objective04 : Objective
{
    private int curRajaKilled = GameStateManager.Instance.rajaKill;
    public override bool IsCompleted()
    {
        
        int rajaKilled = GameStateManager.Instance.rajaKill - curRajaKilled;

        if (rajaKilled >=1)
        {
            return true;
        }
        return false;
    }
}
