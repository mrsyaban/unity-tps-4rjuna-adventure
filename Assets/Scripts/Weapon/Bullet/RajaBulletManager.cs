using UnityEngine;

public class RajaBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    private float damage = 1.5f;

    // float timer;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer >= timeToDestroy) Destroy(gameObject);
    // }

    private void OnCollisionEnter(Collision collision)
    {
        string colliderName = collision.gameObject.name;
        Debug.Log("Collided with: " + colliderName);
        

        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            // string colliderName = collision.gameObject.name;
            // Debug.Log("Collided with: " + colliderName);
            
            if (collision.gameObject.GetComponentInParent<HealthManager>())
            {
                Debug.Log("Damage");
                HealthManager playerHealth = collision.gameObject.GetComponentInParent<HealthManager>();
                playerHealth.TakeDamage(damage);
                Debug.Log("Player : " + playerHealth.health);
            }
            Destroy(gameObject); // Destroy the GameObject this script is attached to
        }

    }
}
