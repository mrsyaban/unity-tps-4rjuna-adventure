using UnityEngine;

public class CheatCodeKillPet :CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeKillPet()
    {
        Code = "cat hater";
        Desc = "Pet killer";
    }
    
    public override void RunCheat()
    {
        
    }
}