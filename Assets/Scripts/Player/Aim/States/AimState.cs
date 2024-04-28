using UnityEngine;

public class AimState : AimStateBase
{
    public override void EnterState(AimStateManager aim)
    {
        aim.anim.SetBool("IsAim", true);
        aim.currentFov = aim.adsFov;
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1)) aim.SwitchState(aim.hip);
    }
}