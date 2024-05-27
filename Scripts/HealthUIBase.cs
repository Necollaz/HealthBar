using UnityEngine;

public abstract class HealthUIBase : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected virtual void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    protected virtual void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    protected abstract void UpdateHealthUI(float currentHealth, float maxHealth);

    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        UpdateHealthUI(currentHealth, maxHealth);
    }
}
