using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KepalaFireState : KepalaKrocoBaseState
{
    public override void EnterState(KepalaKrocoManager manager)
    {
        manager.animator.SetBool("IsFire", true);
    }

    public override void UpdateState(KepalaKrocoManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0) ExitState(manager, manager.walk);
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < 5) ExitState(manager, manager.idle);

        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(KepalaKrocoManager manager, KepalaKrocoBaseState state) 
    {
        manager.animator.SetBool("IsFire", false);
        manager.SwitchState(state);
    }
}