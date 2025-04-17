using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 10f;

    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Start()
    {
        transform.localScale = Vector3.one * 0.3f; // projétil pequeno
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Move em linha reta até o inimigo
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        // Quando chega no alvo
        if (Vector3.Distance(transform.position, _target.position) < 0.1f)
        {
            if (_target.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}
