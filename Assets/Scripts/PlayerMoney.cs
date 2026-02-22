using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public int money = 0;

    public TMP_Text moneyText;

    void Start()
    {
        UpdateUI();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (moneyText != null)
            moneyText.text = "Coin: " + money;
    }
}