using UnityEngine;

public class HPItem : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.AddHP(healAmount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found!");
            }
        }
    }
}