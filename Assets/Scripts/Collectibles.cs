using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
    public TMP_Text keysCollectedText; 
    public GameObject door; 
    public GameObject gameOverPanel; 

    private static int totalKeys = 6; 
    private static int keysCollected = 0;
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            Debug.Log("Player Collision Detected");
            CollectKey();
        }
        else if(gameObject.CompareTag("Door"))
        {
            CheckCompletion();
        }
    }

    private void CollectKey()
    {
        keysCollected++;
        //collected = true;
        UpdateKeysUI();
        Destroy(gameObject); 
        
    }

    private void UpdateKeysUI()
    {
        if (keysCollectedText != null)
        {
            keysCollectedText.text = "Keys Collected: " + keysCollected + " / " + totalKeys;
        }
    }

    private void CheckCompletion()
    {
        if (keysCollected >= totalKeys && door != null)
        {
            PlayerWins();
        }
    }

    private void PlayerWins()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 

            // Display "Player Wins" text 
            TMP_Text gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();
            if (gameOverText != null)
            {
                gameOverText.text = "Player Wins!";
            }
        }
    }
}