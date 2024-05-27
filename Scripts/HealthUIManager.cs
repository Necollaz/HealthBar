using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Text _healthText;
    [SerializeField] private Slider _healthBar;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthUI;
    }

    private void Start()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        _healthText.text = $"{_health.CurrentHealth} / {_health.MaxHealth}";
        _healthBar.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }
}
