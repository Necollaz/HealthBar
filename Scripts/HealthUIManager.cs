using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Text _healthText;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private float _smoothSpeed = 5f;

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
        StartCoroutine(UpdateSmoothHealthBar());
    }

    private IEnumerator UpdateSmoothHealthBar()
    {
        while(Mathf.Abs(_smoothHealthBar.value - (float)_health.CurrentHealth / _health.MaxHealth) > 0.01f)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, (float)_health.CurrentHealth / _health.MaxHealth, Time.deltaTime * _smoothSpeed);
            yield return null;
        }

        _smoothHealthBar.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }
}
