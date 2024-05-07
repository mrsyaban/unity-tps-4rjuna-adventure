using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RajaFireState : RajaBaseState
{
    public override void EnterState(RajaManager manager)
    {
        manager.animator.SetBool("IsFire", true);
    }

    public override void UpdateState(RajaManager manager)
    {
        if (manager.weapon.IsCanFire()) 
        {
            manager._rangeAttackCount--;
            manager.weapon.Fire();
        }
        if (manager.enemyNav.velocity.magnitude > 1) ExitState(manager, manager.walk);
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack) ExitState(manager, manager.fire);

        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(RajaManager manager, RajaBaseState state) 
    {
        manager.animator.SetBool("IsFire", false);
        manager.SwitchState(state);
    }
}