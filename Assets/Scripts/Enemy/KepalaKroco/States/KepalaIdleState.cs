using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KepalaIdleState : KepalaKrocoBaseState
{
    public override void EnterState(KepalaKrocoManager manager)
    {
        manager.animator.SetBool("IsWalking", false);
    }

    public override void UpdateState(KepalaKrocoManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0) manager.SwitchState(manager.walk);
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack) manager.SwitchState(manager.fire);
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}