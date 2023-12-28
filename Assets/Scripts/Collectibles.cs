using UnityEngine;
using TMPro;

public class Collectibles : MonoBehaviour
{
    public TMP_Text keysCollectedText; 
    public GameObject door; 
    public GameObject gameOverPanel; 
    private static int totalKeys = 6; 
    private static int keysCollected = 0;
    private bool doorLocked = true;
    public EnemyAIController[] enemies;

    private void Start()
    {
        keysCollected = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Key"))
            {
                Debug.Log("Player Collision Detected");
                CollectKey();
            }
            else if(gameObject.CompareTag("Door"))
            {
                CheckCompletion();
            }
        }   
    }

    private void CollectKey()
    {
        keysCollected++;
        SoundManager.Instance.Play(Sounds.Keys);
        UpdateKeysUI();
        Destroy(gameObject); 
        
    }

    private void UpdateKeysUI()
    {
        if(keysCollectedText != null)
        {
            keysCollectedText.text = "Keys Collected: " + keysCollected + " / " + totalKeys;
        }
    }

    private void CheckCompletion()
    {
        if(keysCollected >= totalKeys && doorLocked)
        {
            PlayerWins();
        }
    }

    private void PlayerWins()
    {
        doorLocked = false;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
            SoundManager.Instance.Play(Sounds.Door);

            TMP_Text gameOverText = gameOverPanel.GetComponentInChildren<TMP_Text>();
            if (gameOverText != null)
            {
                gameOverText.text = "Player Wins!";
            }

            DestroyEnemies();     //Destroy all enemies :(
        }    
    }

    public void ResetKeysCount()
    {
        keysCollected = 0;
    }

    private void DestroyEnemies()
    {
        enemies = FindObjectsOfType<EnemyAIController>();

        foreach (EnemyAIController enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}