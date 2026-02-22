using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMoney playerMoney = collision.GetComponent<PlayerMoney>();

            if (playerMoney != null)
            {
                playerMoney.AddMoney(value);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerMoney not found on Player!");
            }
        }
    }
}