using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _fill;
    [SerializeField] private Enemy _enemy;

    void Update()
    {
        float ratio = _enemy.CurrentHealth / _enemy.MaxHealth;
        _fill.fillAmount = ratio;

        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
