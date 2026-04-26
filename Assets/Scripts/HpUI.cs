using UnityEngine;
using UnityEngine.UI;
public class HpUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _fillImage;

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= UpdateBar;
        _playerHealth.OnDeath -= DeathBar;
    }
    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += UpdateBar;
        _playerHealth.OnDeath += DeathBar;
    }
    private void Start()
    {
        UpdateBar();
    }
    private void UpdateBar()
    {
        float amount = (float)_playerHealth.Hp / _playerHealth.MaxHp;
        _fillImage.fillAmount = amount;
    }
    private void DeathBar()
    {
        _fillImage.fillAmount = 0;
    }
}
