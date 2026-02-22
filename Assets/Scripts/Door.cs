using UnityEngine;

public class Door : MonoBehaviour
{
    public string sceneName;
    public GameObject winPanel;

    private bool hasTriggered = false; // tránh gọi nhiều lần

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            ShowWinPanel();
        }
    }

    void ShowWinPanel()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}