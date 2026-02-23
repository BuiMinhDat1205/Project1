using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    [Header("Login")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text messageText;
    public GameObject loginPanel;

    [Header("Player Name")]
    public TMP_InputField playerNameInput;
    public GameObject namePanel;

    private string savedUsernameKey = "USERNAME";
    private string savedPasswordKey = "PASSWORD";
    private string savedPlayerNameKey = "PLAYERNAME";

    void Start()
    {
        namePanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // ===== ĐĂNG KÝ =====
    public void Register()
    {
        if (usernameInput.text == "" || passwordInput.text == "")
        {
            messageText.text = "Vui lòng nhập đủ thông tin!";
            return;
        }

        PlayerPrefs.SetString(savedUsernameKey, usernameInput.text);
        PlayerPrefs.SetString(savedPasswordKey, passwordInput.text);
        PlayerPrefs.Save();

        messageText.text = "Đăng ký thành công!";
    }

    // ===== ĐĂNG NHẬP =====
    public void Login()
    {
        string savedUser = PlayerPrefs.GetString(savedUsernameKey);
        string savedPass = PlayerPrefs.GetString(savedPasswordKey);

        if (usernameInput.text == savedUser && passwordInput.text == savedPass)
        {
            messageText.text = "Đăng nhập thành công!";
            loginPanel.SetActive(false);
            namePanel.SetActive(true);
        }
        else
        {
            messageText.text = "Sai tài khoản hoặc mật khẩu!";
        }
    }

    // ===== XÁC NHẬN TÊN =====
    public void ConfirmName()
    {
        if (playerNameInput.text == "")
            return;

        PlayerPrefs.SetString(savedPlayerNameKey, playerNameInput.text);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Menu");
    }
}