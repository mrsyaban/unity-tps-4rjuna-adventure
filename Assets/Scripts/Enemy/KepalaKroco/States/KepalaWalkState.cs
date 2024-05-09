using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KepalaWalkState : KepalaKrocoBaseState
{
    public override void EnterState(KepalaMovementManager manager)
    {
        manager.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(KepalaMovementManager manager)
    {
        if (manager.enemyNav.velocity.magnitude <= 0 && Vector3.Distance(manager.enemy.position, manager.player.position) < 5) manager.SwitchState(manager.idle);
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}