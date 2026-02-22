using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinUI : MonoBehaviour
{
    public string nextSceneName;
    public TMP_Text winCoinText;

    private void OnEnable()
    {
        if (PlayerMoney.Instance != null && winCoinText != null)
        {
            winCoinText.text = ": " + PlayerMoney.Instance.GetMoney();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName);
    }
}