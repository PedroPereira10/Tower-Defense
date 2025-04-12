using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Transform _target;
    private NavMeshAgent _agent;

    public void SetTarget(Transform target)
    {
        _target = target;
        if (_agent == null) _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_target.position);
    }

    void Start()
    {
        if (_agent == null) _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
    }

    void Update()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position);
            _animator.SetFloat("_speed", _agent.velocity.magnitude / _agent.speed);

            // Rotação manual
            if (_agent.velocity.sqrMagnitude > 0.1f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(_agent.velocity.normalized);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            }
        }

        // Trava o Y
        Vector3 pos = transform.position;
        pos.y = 0f;
        transform.position = pos;
    }
}
