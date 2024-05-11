using UnityEngine;

public class RajaBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public RajaWeaponManager weapon; 

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     // string colliderName = other.gameObject.name;
    //     // Debug.Log("Raja Bullet : " + colliderName);
    // }

    private void OnCollisionEnter(Collision collision)
    {   
        // string colliderName = collision.gameObject.name;
        // Debug.Log("Raja Bullet : " + colliderName);

        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {            
            if (collision.gameObject.GetComponentInParent<HealthManager>())
            {
                // Debug.Log("Damage");
                HealthManager playerHealth = collision.gameObject.GetComponentInParent<HealthManager>();
                playerHealth.TakeDamage(weapon.GetBulletDamage());
                Debug.Log("Damage : " + weapon.GetBulletDamage());
            }
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }

    }
}
