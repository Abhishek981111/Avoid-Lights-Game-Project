using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 0.1f; // Distance to stop from player
    public float raycastDistance = 5.0f; 
    public LayerMask obstacleLayer; 
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
                rb.velocity = Vector2.zero;
            }
        }
    }
}