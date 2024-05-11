using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RajaManager : MonoBehaviour
{
    [HideInInspector] public Transform player;
    [HideInInspector] public NavMeshAgent enemyNav;
    [HideInInspector] public Transform enemy;
    [HideInInspector] public Animator animator;

    RajaBaseState currentState;
    [HideInInspector] public int _rangeAttackCount;  
    [HideInInspector] public int _meleAttackCount;  
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
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        // Debug.Log("Velo : " + enemyNav.velocity.magnitude);
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

    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.layer == 3) {
            if (other.gameObject.GetComponentInParent<HealthManager>())
            {
                Debug.Log("AOE Damage");
                HealthManager playerHealth = other.gameObject.GetComponentInParent<HealthManager>();
                playerHealth.TakeDamage(weapon.GetAoEDamage());
                Debug.Log("Player : " + playerHealth.health);
            }
        }   
    }
}
