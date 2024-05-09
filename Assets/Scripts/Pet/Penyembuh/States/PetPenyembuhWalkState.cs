using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PetPenyembuhWalkState : PetPenyembuhBaseState
{
    public override void EnterState(PetPenyembuhManager manager)
    {
        manager.animator.SetBool("Roll_Anim", false);
        manager.animator.SetBool("Walk_Anim", true);
        manager.animator.SetBool("Open_Anim", false);
        manager.petNav.speed = 3.5f;
    }

    public override void UpdateState(PetPenyembuhManager manager)
    {
        if (Vector3.Distance(manager.pet.position, manager.master.position) > 8) { 
            Debug.Log(Vector3.Distance(manager.pet.position, manager.master.position));
            manager.SwitchState(manager.roll);
        }
        else if (Vector3.Distance(manager.pet.position, manager.master.position) < 2)
        {
            Debug.Log(Vector3.Distance(manager.pet.position, manager.master.position));
            manager.SwitchState(manager.idle);
        }
        // Debug.Log("Angular Speed : " +  manager.enemy.velocity.magnitude);
    }
}