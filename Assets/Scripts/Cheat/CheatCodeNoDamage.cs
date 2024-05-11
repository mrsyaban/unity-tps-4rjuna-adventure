using UnityEngine;

public class CheatCodeNoDamage:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }
    
    public CheatCodeNoDamage()
    {
        Code = "imo";
        Desc = "Immortal";
    }
    
    public override void RunCheat()
    {
        
    }
}