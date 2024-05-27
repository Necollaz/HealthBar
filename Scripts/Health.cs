using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _minHealth;

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    public event Action CharecterDied;
    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        if(amount < 0)
        {
            return;
        }

        UpdateHealth(-amount);
    }

    public void Heal(int healthImproving)
    {
        if(healthImproving <= 0)
        {
            return;
        }

        UpdateHealth(healthImproving);
    }

    private void UpdateHealth(int healthChange)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + healthChange, _minHealth, MaxHealth);
        HealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth <= _minHealth)
        {
            CharecterDied?.Invoke();
        }
    }
}