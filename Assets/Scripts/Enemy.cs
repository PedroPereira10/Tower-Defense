using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private int _damageToGoal = 1;
    [SerializeField] private Transform _hitPoint;

    private float _health;

    public int DamageToGoal => _damageToGoal;
    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;
    public Transform HitPoint => _hitPoint != null ? _hitPoint : transform;

    private void Start()
    {
        _health = _maxHealth;

        var rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
        rb.useGravity = false;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        Debug.Log($"Enemy receveid {amount} of damage. Life: {_health}");

        if (_health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }
}
