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
        petNav.destination = master.position;
    }
}
