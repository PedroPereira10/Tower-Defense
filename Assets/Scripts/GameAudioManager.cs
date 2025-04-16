using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance { get; private set; }

    [Header("Game Sounds")]
    [SerializeField] private AudioClip _startGameClip;
    [SerializeField] private AudioClip _gameOverClip;
    [SerializeField] private AudioClip _diamondHitClip;

    [Header("Tower Sounds")]
    [SerializeField] private AudioClip _placeTowerClip;
    [SerializeField] private AudioClip _fireballShotClip;
    [SerializeField] private AudioClip _arrowShotClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayStartGame()
    {
        if (_startGameClip != null)
            _audioSource.PlayOneShot(_startGameClip);
    }

    public void PlayGameOver()
    {
        if (_gameOverClip != null)
            _audioSource.PlayOneShot(_gameOverClip);
    }

    public void PlayDiamondHit()
    {
        if (_diamondHitClip != null)
            _audioSource.PlayOneShot(_diamondHitClip);
    }

    public void PlayPlaceTower()
    {
        if (_placeTowerClip != null)
            _audioSource.PlayOneShot(_placeTowerClip);
    }

    public void PlayFireballShot()
    {
        if (_fireballShotClip != null)
            _audioSource.PlayOneShot(_fireballShotClip);
    }

    public void PlayArrowShot()
    {
        if (_arrowShotClip != null)
            _audioSource.PlayOneShot(_arrowShotClip);
    }
}
