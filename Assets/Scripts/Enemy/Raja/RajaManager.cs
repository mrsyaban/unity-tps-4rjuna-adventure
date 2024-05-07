using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RajaManager : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemyNav;
    public Transform enemy;
    [HideInInspector] public Animator animator;

    RajaBaseState currentState;
    public int _rangeAttackCount;  
    public int _meleAttackCount;  
    public RajaIdleState idle = new RajaIdleState();
    public RajaWalkState walk = new RajaWalkState();
    public RajaFireState fire = new RajaFireState();
    [SerializeField] public RajaWeaponManager weapon;
    [SerializeField] public float distanceAttack;
    [SerializeField] public int meleAttackCount;
    [SerializeField] public int rangeAttackCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        _rangeAttackCount = rangeAttackCount;
        _meleAttackCount = meleAttackCount;  
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Velo : " + enemyNav.velocity.magnitude);
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

    public void SwitchState(RajaBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }
}
