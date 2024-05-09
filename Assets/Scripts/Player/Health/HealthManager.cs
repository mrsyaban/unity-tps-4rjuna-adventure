using UnityEngine;

public class HealthManager : MonoBehaviour {
    [SerializeField] public float maxHealth;
    [HideInInspector] public float health;
    [SerializeField] public PlayerHealthBar playerHealthBar;

    private void Awake()
    {
        health = maxHealth;
        playerHealthBar.UpdateHealthBar(maxHealth, health);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        playerHealthBar.UpdateHealthBar(maxHealth, health);

        if (health <= 0) Death();
    }

    public void Death()
    {
        Animator animator = GetComponent<Animator>();

        animator.SetTrigger("Dead");

        Debug.Log("Death");
    }
}