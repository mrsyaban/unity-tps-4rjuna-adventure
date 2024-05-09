using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrbController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player consumes the food when colliding with it
        {
            HealthManager playerHealth = other.gameObject.GetComponentInParent<HealthManager>();
            if(playerHealth.health >= 85)
            {
                playerHealth.Awake();
            } else {
                playerHealth.TakeDamage(-1.2f * playerHealth.health);
            }
            Consume(); // Call the Consume function when colliding with the player
        }
    }

    private void Consume()
    {
        Destroy(gameObject);
    }
}
