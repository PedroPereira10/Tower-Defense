using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private int _damageToGoal = 1;
    [SerializeField] private Transform _hitPoint;
    [SerializeField] private float _deathDelay = 2f;

    private float _health;
    private Animator _animator;
    private bool _isDying = false;

    public int DamageToGoal => _damageToGoal;
    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;
    public Transform HitPoint => _hitPoint != null ? _hitPoint : transform;

    private void Start()
    {
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if (_isDying) return;

        _health -= amount;
        Debug.Log($"Enemy received {amount} of damage. Life resting: {_health}");

        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDying) return;
        _isDying = true;

        Debug.Log("Enemy dead.");
        _animator.SetTrigger("die");

        Destroy(gameObject, _deathDelay);
    }
}
