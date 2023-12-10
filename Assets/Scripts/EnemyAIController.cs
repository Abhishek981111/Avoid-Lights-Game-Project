using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float stoppingDistance = 1.5f;
    [SerializeField] float explosionRadius = 2f; // Distance to stop from player
    [SerializeField] float raycastDistance = 5.0f; 
    [SerializeField] int explosionDamage = 10;
    public LayerMask obstacleLayer; 
    //public GameObject explosionEffect;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            // Moving towards the player
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                // Checking for obstacles along the path using raycasting
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

                if (hit.collider == null)
                {
                    rb.velocity = direction * speed;
                }
                else
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                //rb.velocity = Vector2.zero;
                Explode();
            }
        }
    }

    void Explode()
    {
        // Instantiate explosion effect at enemy's position
        //Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Find all colliders within the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        // Check each collider for player tag and deal damage if found
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                // Damage the player
                // Replace with player health/damage system
                //col.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);
                Debug.Log("Player damaged by explosion");
            }
        }

        // Destroy the enemy
        Destroy(gameObject);
    }
}