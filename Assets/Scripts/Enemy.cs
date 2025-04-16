using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private int _damageToGoal = 1;
    private float _health;
    public int DamageToGoal => _damageToGoal;


    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _health = _maxHealth; 
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
