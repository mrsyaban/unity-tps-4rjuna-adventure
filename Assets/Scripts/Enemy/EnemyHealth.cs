using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float maxHealth;
    [HideInInspector] public float health;
    [HideInInspector] public ParticleSystem hitParticle;
    [SerializeField] public HealthBar healthBar;

    void Awake()
    {
        hitParticle = GetComponentInChildren<ParticleSystem>();
        health = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, health);
    }

    public void TakeDamage(float damage) 
    {
        Debug.Log("Hit");
        health -= damage;

        hitParticle.Play();

        healthBar.UpdateHealthBar(maxHealth, health);

        if (health <= 0) Death();
    }

    void Death()
    {

        Animator animator = GetComponent<Animator>();

        GetComponent<NavMeshAgent>().enabled = false;

        animator.SetTrigger("Dead");

        Destroy(gameObject, 2.5f);
    } 

}
