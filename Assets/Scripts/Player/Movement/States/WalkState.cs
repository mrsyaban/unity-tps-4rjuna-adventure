using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{    
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("IsWalking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.run);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.idle);
        
        if (movement.vtInput < 0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
    }

    public void ExitState(MovementStateManager movement, MovementBaseState state) {
        movement.animator.SetBool("IsWalking", false);
        movement.SwitchState(state);
    }
}
