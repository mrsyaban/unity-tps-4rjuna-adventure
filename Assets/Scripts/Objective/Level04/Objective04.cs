using TMPro;
using UnityEngine;

public class Objective04 : Objective
{
    
    public override bool IsCompleted()
    {
        int rajaKilled = GameStateManager.Instance.krocoKill;

        if (rajaKilled >=1)
        {
            return true;
        }
        return false;
    }
}
