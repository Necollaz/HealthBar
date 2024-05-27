using UnityEngine;
using UnityEngine.UI;

public class HealthText : HealthUIBase
{
    [SerializeField] private Text _healthText;

    protected override void UpdateHealthUI(float currenHealth, float maxHealth)
    {
        _healthText.text = $"{currenHealth} / {maxHealth}";
    }
}
