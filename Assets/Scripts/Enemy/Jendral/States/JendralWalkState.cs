using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JendralWalkState : JendralBaseState
{
    public override void EnterState(JendralManager manager)
    {
        manager.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(JendralManager manager)
    {
        if (manager.enemyNav.velocity.magnitude <= 0 && Vector3.Distance(manager.enemy.position, manager.player.position) < 2){
            Debug.Log("Distance between enemy and player: " + Vector3.Distance(manager.enemy.position, manager.player.position));
            ExitState(manager, manager.attack);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(JendralManager manager, JendralBaseState state) 
    {
        manager.animator.SetBool("IsWalking", false);
        manager.SwitchState(state);
    }
}