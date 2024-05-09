using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KrocoIdleState : KrocoBaseState
{
    public override void EnterState(KrocoMovementManager manager)
    {
        manager.animator.SetBool("IsWalking", false);
    }

    public override void UpdateState(KrocoMovementManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0) { 
            manager.SwitchState(manager.walk);
        }
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack) { 
            Debug.Log(Vector3.Distance(manager.enemy.position, manager.player.position));
            manager.SwitchState(manager.attack);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}