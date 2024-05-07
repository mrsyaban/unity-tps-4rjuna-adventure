using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RajaWalkState : RajaBaseState
{
    public override void EnterState(RajaManager manager)
    {
        manager.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(RajaManager manager)
    {
        if (manager.enemyNav.velocity.magnitude <= 1 && Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack) manager.SwitchState(manager.idle);
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}