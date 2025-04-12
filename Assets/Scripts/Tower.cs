using UnityEngine;
using UnityEngine.ProBuilder;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float _range = 5f;
    [SerializeField] protected float _fireRate = 1f;
    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected Transform _firePoint;

    protected float _fireCooldown;
    protected Enemy _currentTarget;

    protected virtual void Update()
    {
        _fireCooldown -= Time.deltaTime;

        if (_currentTarget == null || !IsTargetInRange(_currentTarget))
        {
            _currentTarget = FindClosestEnemy();
        }

        if (_currentTarget != null && _fireCooldown <= 0f)
        {
            Shoot();
            _fireCooldown = 1f / _fireRate;
        }

        if (_currentTarget != null)
        {
            Debug.DrawLine(transform.position, _currentTarget.transform.position, Color.red);
            Debug.Log("Atacando: " + _currentTarget.name);
        }

        if (_currentTarget != null)
        {
            Vector3 dir = _currentTarget.transform.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
        }

    }

    protected virtual void Shoot()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Initialize(_currentTarget.transform);
    }

    protected bool IsTargetInRange(Enemy enemy)
    {
        return Vector3.Distance(transform.position, enemy.transform.position) <= _range;
    }

    protected virtual Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy closest = null;
        float closestDist = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist < closestDist && dist <= _range)
            {
                closest = e;
                closestDist = dist;
            }
        }

        return closest;
    }
}
