using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    public UnityEvent OnPlayerDeath;
    private Collectibles collectibles;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI(); 
        collectibles = FindObjectOfType<Collectibles>();
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
        SoundManager.Instance.Play(Sounds.PlayerDie);
        SoundManager.Instance.Play(Sounds.GameOver);

        if (collectibles != null)
        {
            collectibles.ResetKeysCount();
        }
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