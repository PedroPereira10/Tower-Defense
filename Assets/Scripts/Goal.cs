using UnityEngine;
using TMPro;
using System.Collections;

public class Goal : MonoBehaviour
{
    [SerializeField] private int _goalHealth = 10;
    [SerializeField] private float _damageInterval = 1f;
    [SerializeField] private TextMeshProUGUI _goalLifeText;

    private void Start()
    {
        UpdateGoalLifeUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            StartCoroutine(DamageOverTimeCoroutine(enemy));
        }
    }

    public void StartDamage(Enemy enemy)
    {
        StartCoroutine(DamageOverTimeCoroutine(enemy));
    }


    public IEnumerator DamageOverTimeCoroutine(Enemy enemy)
    {
        while (enemy != null && _goalHealth > 0)
        {
            TakeDamage(enemy.DamageToGoal);

            if (enemy.TryGetComponent<Animator>(out var animator))
            {
                animator.SetTrigger("melee attack");
            }

            yield return new WaitForSeconds(_damageInterval);
        }

        if (enemy != null)
        {
            Destroy(enemy.gameObject);
        }
    }



    private void TakeDamage(int amount)
    {
        _goalHealth -= amount;
        UpdateGoalLifeUI();

        Debug.Log("Diamond lost a life! Life's resting: " + _goalHealth);

        GameAudioManager.Instance.PlayDiamondHit(); 

        if (_goalHealth <= 0)
        {
            GameAudioManager.Instance.PlayGameOver(); 
            GameManager.Instance.GameOver();
        }
    }


    private void UpdateGoalLifeUI()
    {
        if (_goalLifeText != null)
            _goalLifeText.text = "" + _goalHealth;
    }
}
