using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthUIBase
{
    [SerializeField] private Slider _healthBar;

    protected override void UpdateHealthUI(float currentHealth, float maxHealth)
    {
        _healthBar.value = currentHealth / maxHealth;
    }
}
