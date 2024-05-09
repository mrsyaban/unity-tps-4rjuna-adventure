using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player consumes the food when colliding with it
        {
            MovementStateManager playerMovement = other.gameObject.GetComponentInParent<MovementStateManager>();
            Debug.Log(playerMovement.speedUpTime);
            playerMovement.speedUpTime = 15000;
            playerMovement.currentMoveSpeed += 1.2f * playerMovement.currentMoveSpeed;
            playerMovement.walkSpeed += 1.2f * playerMovement.walkSpeed;
            playerMovement.walkBackSpeed += 1.2f * playerMovement.walkBackSpeed;
            Consume(); // Call the Consume function when colliding with the player
        }
    }

    private void Consume()
    {
        Destroy(gameObject);
    }
}
