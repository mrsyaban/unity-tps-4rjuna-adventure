using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JendralAttackState : JendralBaseState
{
    public override void EnterState(JendralManager manager)
    {
        manager.animator.SetBool("IsAttack", true);
    }

    public override void UpdateState(JendralManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0) {
            Debug.Log("EnemyNav velocity magnitude: " + manager.enemyNav.velocity.magnitude);
            ExitState(manager, manager.walk);
        }
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) > 2.5) {
            Debug.Log("Vector Distance: " + Vector3.Distance(manager.enemy.position, manager.player.position));
            ExitState(manager, manager.walk);
        }

        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(JendralManager manager, JendralBaseState state) 
    {
        manager.animator.SetBool("IsAttack", false);
        manager.SwitchState(state);
    }
}