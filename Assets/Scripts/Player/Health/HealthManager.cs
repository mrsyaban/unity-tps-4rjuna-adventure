using UnityEngine;

public class HealthManager : MonoBehaviour {
    [SerializeField] public float maxHealth;
    [HideInInspector] public float health;
    [SerializeField] public PlayerHealthBar playerHealthBar;

    public void Awake()
    {
        health = maxHealth;
        playerHealthBar.UpdateHealthBar(maxHealth, health);
        if(GameStateManager.Instance.loadHealth && GameStateManager.Instance.playerHealth != 0)
        {
            health = GameStateManager.Instance.playerHealth;
            GameStateManager.Instance.loadHealth = false;
        } else { GameStateManager.Instance.playerHealth = health; }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        playerHealthBar.UpdateHealthBar(maxHealth, health);
        GameStateManager.Instance.UpdatePlayerHealth(health);

        if (health <= 0) Death();
    }

    public void AddHealth(float heal)
    {
        health += heal;
        playerHealthBar.UpdateHealthBar(maxHealth, health);
    }

    public void Death()
    {
        Animator animator = GetComponent<Animator>();

        animator.SetLayerWeight(1, 0);
        animator.SetTrigger("Dead");
        NextScene.Next("Scenes/CutsceneGameOver");

        Debug.Log("Death");
    }
}