using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;

    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        _animator.SetTrigger(EnemyAnimatorData.Params.Attack);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Умер!");
        Destroy(gameObject);
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }
}