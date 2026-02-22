using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public static PlayerMoney Instance;

    public int money = 0;
    public TMP_Text moneyText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public int GetMoney()
    {
        return money;
    }

    void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "Coin: " + money;
    }
}