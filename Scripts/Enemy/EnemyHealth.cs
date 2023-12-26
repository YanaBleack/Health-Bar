using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;

    public int MaxHealth => _maxHealth;
    public event UnityAction<int> HealthChanged;
    public event UnityAction DamageTaken;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        DamageTaken.Invoke();

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