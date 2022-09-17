using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField, Min(0)] protected int _maxHealth;
    [SerializeField, Min(0)] protected int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public bool IsAlive { get; private set; } = true;

    public event Action OnHealthChanged;
    public event Action OnDied;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException($"Damage can't be less, than 0!");

        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        if (_currentHealth <= 0 && IsAlive)
            Die();
        OnHealthChanged?.Invoke();
    }

    public void Heal(int health)
    {
        if (health < 0)
            throw new ArgumentOutOfRangeException($"Health can't be less, than 0!");
        _currentHealth = Mathf.Clamp(_currentHealth + health, 0, _maxHealth);
        OnHealthChanged?.Invoke();
    }

    protected virtual void Die()
    {
        _currentHealth = 0;
        IsAlive = false;
        OnDied?.Invoke();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
#endif
}

public interface IDamageable
{
    void TakeDamage(int damage);
    event Action OnHealthChanged;
    event Action OnDied;
}
