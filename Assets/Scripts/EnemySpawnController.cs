using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField]private float spawnDelay;
    private bool playerEntered = false;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if(playerController != null && !playerEntered)
        { 
            playerEntered = true;
            Debug.Log("Spawning Enemy");
            StartCoroutine(SpawnEnemyWithDelay());               
        }
    }

    IEnumerator SpawnEnemyWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        Debug.Log("Spawning Enemy");
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
