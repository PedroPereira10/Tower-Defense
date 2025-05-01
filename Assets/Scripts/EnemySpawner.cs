using System.Collections;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawning Settings")]
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _goalTarget;
    [SerializeField] private float _timeBetweenSpawns = 1.5f;
    [SerializeField] private float _timeBetweenRounds = 5f;
    [SerializeField] private int _enemiesIncrementPerRound = 2;
    [SerializeField] private int _initialEnemiesPerRound = 3;
    [SerializeField] private int _maxRounds = 5;


    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private float _waveTextDuration = 2f;

    private int _currentRound = 1;

    private void Start()
    {
        StartCoroutine(SpawnRounds());
    }

    private IEnumerator SpawnRounds()
    {
        while (true)
        {
            int enemiesThisRound = _initialEnemiesPerRound + (_enemiesIncrementPerRound * (_currentRound - 1));

            if (_waveText != null)
                StartCoroutine(ShowWaveText($"Wave {_currentRound}"));

            Debug.Log($"Starting Wave {_currentRound} with {enemiesThisRound} enemies!");

            for (int i = 0; i < enemiesThisRound; i++)
            {
                SpawnRandomEnemy();
                yield return new WaitForSeconds(_timeBetweenSpawns);
            }

            _currentRound++;

            _currentRound++;

            if (_currentRound > _maxRounds)
            {
                GameManager.Instance.WinGame(); 
                yield break;
            }

            yield return new WaitForSeconds(_timeBetweenRounds);
        }
    }

    private void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, _enemyPrefabs.Length);
        int spawnIndex = Random.Range(0, _spawnPoints.Length);

        GameObject enemy = Instantiate(_enemyPrefabs[enemyIndex], _spawnPoints[spawnIndex].position, Quaternion.identity);

        if (enemy.TryGetComponent<EnemyAI>(out var ai))
        {
            ai.SetTarget(_goalTarget);
        }
    }

    private IEnumerator ShowWaveText(string message)
    {
        _waveText.text = message;
        _waveText.gameObject.SetActive(true);

        yield return new WaitForSeconds(_waveTextDuration);

        _waveText.gameObject.SetActive(false);
    }
}
