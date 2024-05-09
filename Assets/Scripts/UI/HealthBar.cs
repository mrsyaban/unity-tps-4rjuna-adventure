using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    [SerializeField] private Image healthBar;
    private Camera cam;

    private void Start() 
    {
        cam = Camera.main;    
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    private void Update() 
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);    
    }
}