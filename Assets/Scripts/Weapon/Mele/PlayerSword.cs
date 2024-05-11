using System.Data.Common;
using UnityEngine;

public class PlayerSword : MonoBehaviour 
{
    private float damage = 0;
    private void OnCollisionEnter(Collision other)
    {
        string colliderName = other.gameObject.name;
        Debug.Log("Sword collide with: " + colliderName);
        if (other.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            Debug.Log("Darah : " + enemyHealth.health);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            Debug.Log("Darah : " + enemyHealth.health);
        }
    }

    public void SetDamage(float damage = 50)
    {
        this.damage = damage;
    }
}