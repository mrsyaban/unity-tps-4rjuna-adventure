using UnityEngine;

public abstract class CheatCodeBase
{
    public abstract string Code { get; protected set; }
    public abstract string Desc { get; protected set; }

    public abstract void RunCheat();
    
}