using UnityEngine;
using System.Collections;

public class TrapDamageSlow : MonoBehaviour
{
    [Header("Damage")]
    public int damage = 10;
    public float damageCooldown = 1f;

    [Header("Slow")]
    public float slowMultiplier = 0.3f;
    public float slowDuration = 0.8f;

    private bool canDamage = true;
    private bool isSlowing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canDamage)
        {
            PlayerHealth hp = collision.GetComponent<PlayerHealth>();
            if (hp != null)
                hp.TakeDamage(damage);

            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null && !isSlowing)
                StartCoroutine(SlowPlayer(player));

            StartCoroutine(DamageCooldown());
        }
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    IEnumerator SlowPlayer(PlayerController player)
    {
        isSlowing = true;

        // luôn lấy tốc độ gốc
        float originalSpeed = player.normalSpeed;

        // slow dựa trên tốc độ gốc, không phải speed hiện tại
        player.speed = originalSpeed * slowMultiplier;

        yield return new WaitForSeconds(slowDuration);

        // trả về tốc độ gốc
        player.speed = originalSpeed;

        isSlowing = false;
    }

    IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}