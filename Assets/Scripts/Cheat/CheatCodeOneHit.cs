using UnityEngine;

public class CheatCodeOneHit:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeOneHit()
    {
        Code = "infinity war";
        Desc = "Infinity Damage";
    }
    
    public override void RunCheat()
    {
        
    }
}