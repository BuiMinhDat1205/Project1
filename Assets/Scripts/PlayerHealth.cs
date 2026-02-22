using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public TMP_Text hpText;

    public GameObject gameOverPanel; // kéo panel vào đây

    void Start()
    {
        currentHP = maxHP;
        UpdateUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }

        UpdateUI();
    }

    public void AddHP(int amount)
    {
        currentHP += amount;

        if (currentHP > maxHP)
            currentHP = maxHP;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (hpText != null)
            hpText.text = "HP " + currentHP;
    }

    void Die()
    {
        Debug.Log("Player Dead");

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f; // dừng game
    }
}