using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    public UnityEvent OnPlayerDeath;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI(); 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateUI(); 
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        OnPlayerDeath.Invoke();
    }

    private void UpdateUI()
    {
        // Updating current health to UI
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}