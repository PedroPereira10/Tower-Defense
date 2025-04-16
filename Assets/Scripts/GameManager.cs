using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerLives = 10;
    [SerializeField] private GameObject _gameOverPanel;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        GameAudioManager.Instance.PlayStartGame(); 
    }

    public void LoseLife()
    {
        _playerLives--;
        if (_playerLives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0f;
        GameAudioManager.Instance.PlayGameOver(); 
        _gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
