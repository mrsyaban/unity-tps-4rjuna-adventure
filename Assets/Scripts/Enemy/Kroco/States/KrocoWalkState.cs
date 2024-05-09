using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KrocoWalkState : KrocoBaseState
{
    public override void EnterState(KrocoManager manager)
    {
        manager.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(KrocoManager manager)
    {
        if (manager.enemyNav.velocity.magnitude <= 0 && Vector3.Distance(manager.enemy.position, manager.player.position) < 2)
        {
            Debug.Log("From Walk - Attack :Distance between enemy and player: " + Vector3.Distance(manager.enemy.position, manager.player.position));
            ExitState(manager, manager.attack);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(KrocoManager manager, KrocoBaseState state)
    {
        manager.animator.SetBool("IsWalking", false);
        manager.SwitchState(state);
    }
}