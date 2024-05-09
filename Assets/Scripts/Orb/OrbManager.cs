using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public GameObject[] orbPrefabs; // Array of orb prefabs
    public float deathDelay = 2f; // Delay before player death animation and destruction

    public void DropRandomOrb()
    {
        
        int randomIndex = Random.Range(0, orbPrefabs.Length);

        Instantiate(orbPrefabs[randomIndex], transform.position, Quaternion.identity);
    }
}

