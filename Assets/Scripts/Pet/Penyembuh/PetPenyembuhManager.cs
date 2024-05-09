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
    private float distance = 5;

    [HideInInspector] public Animator animator;

    PetPenyembuhBaseState currentState;
    public PetPenyembuhIdleState idle = new();
    public PetPenyembuhWalkState walk = new();
    public PetPenyembuhRollState roll = new();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SwitchState(idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(pet.position, master.position) >= 2)
        {
            petNav.destination = master.position;
            Debug.Log("Masuk master jadi dest");
        }
        else
        {
            Debug.Log("Masuk pet sendiri jadi dest");
            petNav.destination = pet.position;
            Quaternion lookRotation = Quaternion.LookRotation(master.position - pet.position);

            // Mengatur rotasi pet
            pet.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
            // SwitchState(fire);
        }
        currentState.UpdateState(this);
        Debug.Log(petNav.destination);
    }

    public void SwitchState(PetPenyembuhBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
