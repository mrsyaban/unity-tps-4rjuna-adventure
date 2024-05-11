using UnityEngine;
using UnityEngine.AI;

public class PetHealth : EnemyHealth
{
    private void Update() 
    {
        if (isDead) {
            float moveDistance = 1.2f * Time.deltaTime;
            transform.Translate(0, -moveDistance, 0);

            if (transform.position.y  < 0.1)
            {
                Destroy(gameObject);
            }
        }    
    }

    void Awake()
    {
        hitParticle = GetComponentInChildren<ParticleSystem>();
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
    }

    void Death()
    {
        if(isDead) return;
        isDead = true;

        GetComponent<NavMeshAgent>().enabled = false;

        Destroy(gameObject, 2.5f);

        Debug.Log("Destroy");
    } 
}
