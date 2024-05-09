using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JendralSwordManager : MonoBehaviour
{
    private float damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        string colliderName = other.gameObject.name;
        Debug.Log("Collided with: " + colliderName);
        
        if (other.gameObject.GetComponentInParent<HealthManager>())
        {
            Debug.Log("Damage");
            HealthManager playerHealth = other.gameObject.GetComponentInParent<HealthManager>();
            playerHealth.TakeDamage(damage);
        }
    }
}
