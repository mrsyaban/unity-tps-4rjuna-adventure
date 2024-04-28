using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("IsRun", true);
    }
    
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.walk);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.idle);
    }
    
    public void ExitState(MovementStateManager movement, MovementBaseState state) {
        movement.animator.SetBool("IsRun", false);
        movement.SwitchState(state);
    }
}
