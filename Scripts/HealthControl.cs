using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _takeDamageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private int _healthImproving = 20;

    private void Start()
    {
        _takeDamageButton.onClick.AddListener(() => _health.TakeDamage(_damageAmount));
        _healButton.onClick.AddListener(() => _health.Heal(_healthImproving));
    }
}
