using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KrocoManager : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemyNav;
    public Transform enemy;
    [HideInInspector] public Animator animator;

    KrocoBaseState currentState;
    public KrocoIdleState idle = new();
    public KrocoWalkState walk = new();
    public KrocoAttackState attack = new();

    // Start is called before the first frame update
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Distance : " + Vector3.Distance(enemy.position, player.position));
        if (Vector3.Distance(enemy.position, player.position) >= 2) enemyNav.destination = player.position;
        else
        {
            enemyNav.destination = enemy.position;
            Quaternion lookRotation = Quaternion.LookRotation(player.position - enemy.position);

            // Mengatur rotasi enemy
            enemy.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            // SwitchState(fire);
        }
        currentState.UpdateState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kroco Called Trigger GetHit");
        this.animator.SetTrigger("GetHit");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Kroco Called ResetTrigger GetHit");
        this.animator.ResetTrigger("GetHit");
    }

    public void SwitchState(KrocoBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
