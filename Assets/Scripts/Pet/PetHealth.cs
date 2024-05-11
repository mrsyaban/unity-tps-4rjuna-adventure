using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetHealth : MonoBehaviour
{
    public float startingHealth = 100f;
    public float currentHealth;
    protected PetManager manager;
    public float healthToBeReduced = 0;

    public void SetManager(PetManager manager)
    {
        this.manager = manager;
    }
}
