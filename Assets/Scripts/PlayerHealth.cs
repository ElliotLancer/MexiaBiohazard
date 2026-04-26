using System;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    [SerializeField] private int _hp = 100;
    [SerializeField] private ArmSwaper _swapArm;
    [SerializeField] private PlayerFlash flash;
    public event Action OnHealthChanged;
    public event Action OnDeath;
    public int Hp => _hp;
    public int MaxHp => _maxHp;
    private void Start()
    {
        _hp = _maxHp;
        OnHealthChanged?.Invoke();
    }
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        flash.Flash();

        if(_hp <= 0)
        {
            Die();
        }
        OnHealthChanged?.Invoke();
        if (_hp < 0)
            _hp = 0;
        
    }
    public void Die()
    {
        Debug.Log("player died");
        GetComponent<PlayerRagdoll>().EnableRagdoll();
        _swapArm.SwapToDead();
        OnDeath?.Invoke();
    }
}
