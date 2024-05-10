using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;

public class PetPenyembuhManager : MonoBehaviour
{
    [SerializeField] public Transform master;
    public NavMeshAgent petNav;
    public Transform pet;
    public float healingDistance;
    public GameObject playerObject;
    public int healPerTime;
    public float timeToHeal;
    [HideInInspector] public Animator animator;
    PetPenyembuhBaseState currentState;
    public PetPenyembuhIdleState idle = new();
    public PetPenyembuhWalkState walk = new();
    public PetPenyembuhRollState roll = new();

    HealthManager playerHealth;
    float timerTick = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<HealthManager>();

        animator = GetComponent<Animator>();
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(pet.position, master.position) >= 2)
        {
            petNav.destination = master.position;
        }
        else
        {
            petNav.destination = pet.position;
            Quaternion lookRotation = Quaternion.LookRotation(master.position - pet.position);

            // Mengatur rotasi pet
            pet.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
        }
        currentState.UpdateState(this);

        if (Vector3.Distance(pet.position, master.position) <= healingDistance)
        {
            timerTick += Time.deltaTime;
            // Belum handle Misal game dipause tapi dalam area heal
            if(timerTick >= timeToHeal)
            {
                timerTick = 0f;
                playerHealth.AddHealth(healPerTime);
            }
        }
    }

    public void SwitchState(PetPenyembuhBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
