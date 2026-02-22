using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectionRange)
        {
            float direction = player.position.x - transform.position.x;

            rb.linearVelocity = new Vector2(
                Mathf.Sign(direction) * moveSpeed,
                rb.linearVelocity.y
            );

            // FIX flip đúng hướng
            sr.flipX = direction > 0;
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
    }
}