using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JendralIdleState : JendralBaseState
{
    public override void EnterState(JendralManager manager)
    {
        manager.animator.SetBool("IsWalking", false);
    }

    public override void UpdateState(JendralManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0) manager.SwitchState(manager.walk);
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) < 2) 
        Debug.Log(Vector3.Distance(manager.enemy.position, manager.player.position));
        manager.SwitchState(manager.attack);
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}