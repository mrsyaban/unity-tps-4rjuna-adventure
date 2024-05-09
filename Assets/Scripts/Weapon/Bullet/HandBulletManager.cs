using UnityEngine;

public class HandBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    private float damage = 10;
    // float timer;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer >= timeToDestroy) Destroy(this.gameObject);
    // }

    private void OnCollisionEnter(Collision collision)
    {
        string colliderName = collision.gameObject.name;
        Debug.Log("On Collided with: " + colliderName);
        
        if (collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            Debug.Log("[In Parent] Darah : " + enemyHealth.health);
        } 
        // else if (collision.gameObject.GetComponent<EnemyHealth>())
        // {
        //     EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        //     enemyHealth.TakeDamage(damage);
        //     Debug.Log("[In Mine] Darah : " + enemyHealth.health);
        // }
        Destroy(gameObject);
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     string colliderName = other.gameObject.name;
    //     Debug.Log("On Triggered with: " + colliderName);
        
    //     if (other.gameObject.GetComponentInParent<EnemyHealth>())
    //     {
    //         Debug.Log("Damage");
    //         EnemyHealth playerHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
    //         playerHealth.TakeDamage(damage);
    //     }
    //     Destroy(gameObject);
    // }
}
