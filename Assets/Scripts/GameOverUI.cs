using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Replay()
    {
        Time.timeScale = 1f;

        // reload scene hiện tại (scene 1 hoặc scene 2 đều được)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // nếu có menu
    }
}