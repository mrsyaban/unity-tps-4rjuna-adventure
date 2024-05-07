using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RajaMeleState : RajaBaseState
{
    public override void EnterState(RajaManager manager)
    {
        manager.animator.SetBool("IsMele", true);
    }

    public override void UpdateState(RajaManager manager)
    {
        manager._meleAttackCount--;
        manager.weapon.Fire();
        if (manager.enemyNav.velocity.magnitude > 1) ExitState(manager, manager.walk);
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < manager.distanceAttack) ExitState(manager, manager.fire);
    }

    public void ExitState(RajaManager manager, RajaBaseState state) 
    {
        manager.animator.SetBool("IsMele", false);
        manager.SwitchState(state);
    }
}