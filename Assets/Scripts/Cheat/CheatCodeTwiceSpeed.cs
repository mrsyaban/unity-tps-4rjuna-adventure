using UnityEngine;

public class CheatCodeTwiceSpeed:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeTwiceSpeed()
    {
        Code = "flash";
        Desc = "Super speed";
    }
    public override void RunCheat()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MovementStateManager movement = player.GetComponent<MovementStateManager>();
        movement.currentMoveSpeed *= 2; 
    }
}