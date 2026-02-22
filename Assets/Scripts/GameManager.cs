using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    public int currentHP = 5;
    public int maxHP = 5;
    public int coins = 0;

    [Header("UI")]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI hpText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coins += amount;
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
        coinText.text = "Coins: " + coins;
        hpText.text = "HP: " + currentHP;
    }
}