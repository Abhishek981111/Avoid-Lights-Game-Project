using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthSlider;
    // public Transform player;
    // public Transform healthSliderTransform;
    // private Quaternion initialRotation;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI(); 

        // if (healthSliderTransform != null)
        // {
        //     initialRotation = healthSliderTransform.rotation;
        // }
    }

    // void Update()
    // {
    //     if (player != null && healthSliderTransform != null)
    //     {
    //         Vector3 abovePlayerHead = player.position + Vector3.up * 1; //*Distance above head to multiply
    //         healthSliderTransform.position = abovePlayerHead;

    //         //initial rotation to maintain consistent orientation
    //         healthSliderTransform.rotation = initialRotation;
    //     }
    // }

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
        // Implement actions of player death (game over and respawn logic)
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