using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public string nextSceneName;

    public void Resume()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneName);
    }
}