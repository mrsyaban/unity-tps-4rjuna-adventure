using UnityEngine;

public class HipFireState : AimStateBase
{
    public override void EnterState(AimStateManager aim)
    {
        aim.anim.SetBool("IsAim", false);
        aim.currentFov = aim.hipFov;
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKey(KeyCode.Mouse1)) aim.SwitchState(aim.ads);
    }
}