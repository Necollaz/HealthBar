using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _minHealth;

    public int Current { get; private set; }
    public int Max { get; private set; }

    public event Action CharecterDied;
    public event Action<float, float> HealthChanged;

    private void Awake()
    {
        Max = 100;
        Current = Max;
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
        Current = Mathf.Clamp(Current + healthChange, _minHealth, Max);
        HealthChanged?.Invoke(Current, Max);

        if (Current <= _minHealth)
        {
            CharecterDied?.Invoke();
        }
    }
}