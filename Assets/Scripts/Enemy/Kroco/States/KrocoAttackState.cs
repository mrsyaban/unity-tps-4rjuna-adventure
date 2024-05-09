using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KrocoAttackState : KrocoBaseState
{
    public override void EnterState(KrocoMovementManager manager)
    {
        Debug.Log("Enter Attack");
        manager.animator.SetBool("IsAttack", true);
    }

    public override void UpdateState(KrocoMovementManager manager)
    {
        if (manager.enemyNav.velocity.magnitude > 0)
        {
            Debug.Log("EnemyNav Kroco velocity magnitude: " + manager.enemyNav.velocity.magnitude);
            Debug.Log("Musuh gerak, masuk walk");
            ExitState(manager, manager.walk);
        }
        else if (Vector3.Distance(manager.enemy.position, manager.player.position) > manager.distanceAttack)
        {
            Debug.Log("Kroco - player Vector Distance: " + Vector3.Distance(manager.enemy.position, manager.player.position));
            Debug.Log("Musuh gerak, masuk walk");
            ExitState(manager, manager.walk);
        }

        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }

    public void ExitState(KrocoMovementManager manager, KrocoBaseState state)
    {
        manager.animator.SetBool("IsAttack", false);
        manager.SwitchState(state);
    }
}