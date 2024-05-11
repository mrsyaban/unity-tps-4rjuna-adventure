using UnityEngine;

public class CheatCodeMotherlode:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeMotherlode()
    {
        Code = "crazy rich";
        Desc = "Infinity money";
    }
    
    public override void RunCheat()
    {
        GameStateManager.Instance.AddCoin(999999);
    }
}