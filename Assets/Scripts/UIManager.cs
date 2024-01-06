using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button lobbyButton;

    void Start()
    {
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        if (lobbyButton != null)
        {
            lobbyButton.onClick.AddListener(LoadLobby);
        }

        // Subscribe to the player's death event
        FindObjectOfType<PlayerHealthController>().OnPlayerDeath.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        gameOverPanel.SetActive(true);

        //Disable player movement 
        PlayerController playerController = FindObjectOfType<PlayerController>();
        if(playerController != null)
        {
            playerController.enabled = false;
        }
    }

    public void RestartGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLobby()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene("Lobby");
    }
}
