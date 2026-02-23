using UnityEngine;
using TMPro;

public class PlayerNameDisplay : MonoBehaviour
{
    public TMP_Text playerNameText;

    void Start()
    {
        string name = PlayerPrefs.GetString("PLAYERNAME");
        playerNameText.text = " " + name;
    }
}