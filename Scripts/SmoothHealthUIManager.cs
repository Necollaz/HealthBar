using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthUIManager : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _smoothHealthBar;
    [SerializeField] private float _smoothSpeed = 5f;

    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        StartSmoothBarUpdate();
    }

    private void OnHealthChanged()
    {
        StartSmoothBarUpdate();
    }

    private void StartSmoothBarUpdate()
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(UpdateSmoothHealthBar());
    }

    private IEnumerator UpdateSmoothHealthBar()
    {
        while (Mathf.Abs(_smoothHealthBar.value - (float)_health.CurrentHealth / _health.MaxHealth) > 0.01f)
        {
            _smoothHealthBar.value = Mathf.MoveTowards(_smoothHealthBar.value, (float)_health.CurrentHealth / _health.MaxHealth, Time.deltaTime * _smoothSpeed);
            yield return null;
        }

        _smoothHealthBar.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }
}
