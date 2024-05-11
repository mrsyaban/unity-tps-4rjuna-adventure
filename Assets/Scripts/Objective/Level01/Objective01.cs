using UnityEngine;


public class Objective01: Objective
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform finishPoint;

    public override bool IsCompleted()
    {
        float playerDistance = Vector3.Distance(finishPoint.position, player.position);
        if (playerDistance < 3f)
        {
            return true;
        }
        return false;
    }
}
