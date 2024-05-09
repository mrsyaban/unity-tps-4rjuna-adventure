using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KepalaMovementManager : MonoBehaviour
{
    [HideInInspector] public Transform player;
    [HideInInspector] public NavMeshAgent enemyNav;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public Animator animator;

    KepalaKrocoBaseState currentState;
    public KepalaIdleState idle = new KepalaIdleState();
    public KepalaWalkState walk = new KepalaWalkState();
    public KepalaFireState fire = new KepalaFireState();
    [SerializeField] public KepalaWeaponManager weapon;
    [SerializeField] public float distanceAttack; 

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
        animator = GetComponent<Animator>();  
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemy.position, player.position) > distanceAttack) enemyNav.destination = player.position;
        else { 
            enemyNav.destination = enemy.position;
            Quaternion lookRotation = Quaternion.LookRotation(player.position - enemy.position);
        
            // Mengatur rotasi enemy
            enemy.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            // SwitchState(fire);
        }
        currentState.UpdateState(this);
    }

    public void SwitchState(KepalaKrocoBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }
}
