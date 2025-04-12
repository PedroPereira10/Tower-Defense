using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _explosionRadius = 0f; // 0 = sem dano em área

    private Transform _target;

    public void Initialize(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject); // Se o inimigo morreu no meio do caminho
            return;
        }

        Vector3 direction = (_target.position - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(direction);

        transform.position += direction * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        if (_explosionRadius > 0f)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(_damage);
                }
            }
        }
        else
        {
            if (_target.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }

        // Destroi o projétil ao atingir o alvo
        Destroy(gameObject);
    }

}
