using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
    [SerializeField] private Image healthBar;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}