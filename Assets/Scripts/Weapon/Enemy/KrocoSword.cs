using UnityEngine;

public class KrocoSword : MonoBehaviour 
{
    private float damage = 5;

    // private void Update() 
    // {
    //     Debug.Log("Kroco");
    // }

    private void OnTriggerEnter(Collider other) 
    {
        string colliderName = other.gameObject.name;
        Debug.Log("Collided with: " + colliderName);
        // if (!other.gameObject.CompareTag("PlayerBullet"))
        // {
            
            // if (collision.gameObject.GetComponentInParent<HealthManager>())
            // {
            //     Debug.Log("Damage");
            //     HealthManager playerHealth = collision.gameObject.GetComponentInParent<HealthManager>();
            //     playerHealth.TakeDamage(damage);
            //     Debug.Log("Player : " + playerHealth.health);
            // }
            // Destroy(gameObject); // Destroy the GameObject this script is attached to
        // }
    }     
}