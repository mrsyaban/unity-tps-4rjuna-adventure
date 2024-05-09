using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KrocoWalkState : KrocoBaseState
{
    public override void EnterState(KrocoMovementManager manager)
    {
        manager.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(KrocoMovementManager manager)
    {
        if (manager.enemyNav.velocity.magnitude <= 0 && Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack)
        {
            // Debug.Log("From Walk - Attack :Distance between enemy and player: " + Vector3.Distance(manager.enemy.position, manager.player.position));
            ExitState(manager, manager.attack);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(KrocoMovementManager manager, KrocoBaseState state)
    {
        manager.animator.SetBool("IsWalking", false);
        manager.SwitchState(state);
    }
}