using UnityEngine;

public class CheatCodeSkip:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeSkip()
    {
        Code = "skip kelas";
        Desc = "Skip";
    }
    
    public override void RunCheat()
    {
        
    }
}