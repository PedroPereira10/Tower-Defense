using UnityEngine;
using UnityEngine.AI;

public class EnemyGoalChaser : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    private Goal _goal;
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool _hasStartedAttack = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _goal = FindObjectOfType<Goal>();

        _goal = FindObjectOfType<Goal>();
        if (_goal != null)
        {
            _agent.SetDestination(_goal.transform.position);
        }
        else
        {
            Debug.LogError("None object with this script was found in the scene!");
        }

    }
    private void Update()
    {
        if (_goal == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, _goal.transform.position);

        if (!_hasStartedAttack && distance <= _attackRange)
        {
            
            _hasStartedAttack = true;

            if (_agent != null)
                _agent.isStopped = true;

            Enemy enemy = GetComponent<Enemy>();
            if (enemy != null)
            {
                _goal.StartDamage(enemy);
            }
            else
            {
            }
        }
    }
}

