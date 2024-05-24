using UnityEngine;

public class PetAttackerBulletManager : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    float timer;
    private float damage = 2;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToDestroy) Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("PlayerPet"))
        {
            if (collision.gameObject.GetComponentInParent<EnemyHealth>())
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
                Debug.Log("[In Parent] Darah : " + enemyHealth.health);
            } 
            Destroy(gameObject);
        }
    }
}