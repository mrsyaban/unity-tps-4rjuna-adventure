using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PetPenyembuhIdleState : PetPenyembuhBaseState
{
    public override void EnterState(PetPenyembuhManager manager)
    {
        manager.animator.SetBool("Roll_Anim", false);
        manager.animator.SetBool("Walk_Anim", false);
        manager.animator.SetBool("Open_Anim", true);
        manager.petNav.speed = 0;
    }

    public override void UpdateState(PetPenyembuhManager manager)
    {
        if (Vector3.Distance(manager.master.position, manager.pet.position) > 2) { 
            manager.SwitchState(manager.walk);
        }
        else if (Vector3.Distance(manager.pet.position, manager.master.position) > 8) { 
            Debug.Log(Vector3.Distance(manager.pet.position, manager.master.position));
            manager.SwitchState(manager.roll);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}