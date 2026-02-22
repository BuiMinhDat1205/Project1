using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinAmount = 5;

    public GameObject pressEText;

    private bool playerNear = false;
    private bool opened = false;

    void Update()
    {
        if (playerNear && !opened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        opened = true;

        float spacing = 0.6f; // khoảng cách giữa coin
        float startX = transform.position.x - (coinAmount - 1) * spacing / 2;

        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 spawnPos = new Vector3(
                startX + i * spacing,
                transform.position.y, // cùng hàng với rương
                0
            );

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }

        if (pressEText != null)
            pressEText.SetActive(false);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = true;
            if (pressEText != null)
                pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNear = false;
            if (pressEText != null)
                pressEText.SetActive(false);
        }
    }
}