using UnityEngine;

public class CheatCodeOrb:CheatCodeBase
{
    public override string Code { get; protected set; }
    public override string Desc { get; protected set; }

    public CheatCodeOrb()
    {
        Code = "organda";
        Desc = "Power up";
    }
    
    public override void RunCheat()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        HealthManager health = player.GetComponent<HealthManager>();
        health.AddHealth(20);
    }
}