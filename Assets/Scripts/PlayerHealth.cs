using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _hp;
    [SerializeField] private bool _isAlive;
    [SerializeField] private ArmSwaper _swapArm;
    [SerializeField] private PlayerFlash _playerFlash;

    private PlayerRagdoll _playerRagdoll;

    public event Action OnHealthChanged;
    public event Action OnDeath;

    public bool IsAlive => _isAlive;
    public int Hp => _hp;
    public int MaxHp => _maxHp;
    private void Awake()
    {
        _playerRagdoll = GetComponent<PlayerRagdoll>();
    }
    private void Start()
    {
        _hp = _maxHp;
        _isAlive = true;
        OnHealthChanged?.Invoke();
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        _hp = Mathf.Max(0, _hp);

        _playerFlash.Flash();
        OnHealthChanged?.Invoke();

        if(_hp == 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (!_isAlive)
            return;

        _playerRagdoll.EnableRagdoll();
        _swapArm.SwapToDead();
        OnDeath?.Invoke();
        _isAlive = false;
    }
}
