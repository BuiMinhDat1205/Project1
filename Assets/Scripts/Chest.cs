using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinAmount = 5;

    public GameObject pressEText;

    private bool playerNear = false;
    private bool opened = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

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

        if (anim != null)
            anim.SetTrigger("open");

        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 spawnPos = transform.position +
                new Vector3(Random.Range(-0.5f, 0.5f), 1f, 0);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
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