
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _maxHealthBar;
    [SerializeField] private Image _currentHealthbar;

    private void Start()
    {
        _maxHealthBar.fillAmount = (float)(_playerHealth.currentHealth * 0.1);
    }

    private void Update()
    {
        _currentHealthbar.fillAmount = (float)(_playerHealth.currentHealth * 0.1);
        _maxHealthBar.fillAmount = (float)(_playerHealth.maxHealth * 0.1);
    }

}
