using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private float _attackTime = 1f;

    private Animator _animator;
    private bool _isAttacking = false;
    private EnemyMovement _movement;
    private PlayerHealth _playerHealth;
    private bool _playerInRange;

    private void Start()
    {
        _movement = GetComponentInParent<EnemyMovement>();
        _animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerInRange = true;
        _playerHealth = other.GetComponent<PlayerHealth>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;
        _playerInRange = false;
    }
    private void Update()
    {
        if(!_isAttacking && _playerInRange)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        if (_movement != null)
            _movement.canMove = false;
        _animator.SetTrigger("Attack");
        yield return new WaitForSeconds(_attackTime);
        Attack();
        yield return new WaitForSeconds(_attackCooldown);

        if (_movement != null)
            _movement.canMove = true;

        _isAttacking = false;
    }
    public void Attack()
    {
        if (_playerInRange && _playerHealth != null)
        {
            _playerHealth.TakeDamage(_damage);
        }
    }
}
