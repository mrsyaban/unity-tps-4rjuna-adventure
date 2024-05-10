using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PetIncreaseManager : MonoBehaviour
{
    [HideInInspector] public Transform master;
    [HideInInspector] public NavMeshAgent petNav;
    [HideInInspector] public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Raja").transform;
        petNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        petNav.destination = master.position;
    }

    private void OnTriggerStay(Collider other)
    {
        string colliderName = other.gameObject.name;
        if (colliderName == "Raja" && other.gameObject.GetComponent<RajaWeaponManager>())
        {
            RajaWeaponManager rajaWeapon = other.gameObject.GetComponent<RajaWeaponManager>();
            rajaWeapon.GiveBuff(int.Parse(gameObject.name[-1].ToString()));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        string colliderName = other.gameObject.name;
        if (colliderName == "Raja" && other.gameObject.GetComponent<RajaWeaponManager>())
        {
            RajaWeaponManager rajaWeapon = other.gameObject.GetComponent<RajaWeaponManager>();
            rajaWeapon.ClearBuff(int.Parse(gameObject.name[-1].ToString()));
        }
    }
}
