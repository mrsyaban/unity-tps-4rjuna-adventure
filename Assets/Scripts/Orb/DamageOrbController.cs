using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOrbController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player consumes the food when colliding with it
        {
            // TODO: Increase player damage
            //  Example:
            // DamageStateManager playerDamage = other.gameObject.GetComponentInParent<DamageStateManager>();
            // playerDamage = 1.1f * playerDamage.currentDamage
            Consume(); // Call the Consume function when colliding with the player
        }
    }

    private void Consume()
    {
        GameStateManager.Instance.UpdateDamageOrbStatus();
        Destroy(gameObject);
    }
}
