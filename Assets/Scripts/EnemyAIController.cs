using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    [SerializeField] float explosionRadius; 
    [SerializeField] float raycastDistance; 
    [SerializeField] int explosionDamage;
    public LayerMask obstacleLayer; 
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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

    private void Explode()
    {
        // Find all colliders within the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        // Check each collider for player tag and deal damage if found
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                PlayerHealthController playerHealthController = col.GetComponent<PlayerHealthController>();
                if(playerHealthController != null)
                {
                    playerHealthController.TakeDamage(explosionDamage);
                    Debug.Log("Player damaged by explosion");
                }
            }
        }

        // Destroy the enemy
        Destroy(gameObject);
        SoundManager.Instance.Play(Sounds.EnemyExplosion);
    }
}