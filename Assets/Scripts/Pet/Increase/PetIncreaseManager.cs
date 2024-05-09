using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PetIncreaseManager : MonoBehaviour
{
    public Transform master;
    public NavMeshAgent petNav;
    public Transform enemy;
    private float distance = 5; 

    // Start is called before the first frame update
    void Start()
    {
        petNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(enemy.position, master.position) > distance) petNav.destination = master.position;
        // else { 
        //     petNav.destination = enemy.position;
        //     Quaternion lookRotation = Quaternion.LookRotation(master.position - enemy.position);
        
        //     // Mengatur rotasi enemy
        //     enemy.rotation = Quaternion.Euler(0f, lookRotation.eulerAngles.y, 0f);
        //     // SwitchState(fire);
        // }
        petNav.destination = master.position;
    }
}
