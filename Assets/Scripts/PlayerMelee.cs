using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius = 1f;
    [SerializeField] private float _attackCooldown = 0.3f;
    [SerializeField] private int _damage = 8;
    [SerializeField] private Animator _hands;
    [SerializeField] private Coroutine _attackRoutine;
    private Vector3 _startPos;
    private bool _isAttacking;
    private bool _canAttack = true;
    private void Awake()
    {
        _startPos = transform.localPosition;
    }
    private void Update()
    {
        if (_canAttack)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }
    private void Attack()
    {
        if (_isAttacking)
            return;
        _attackRoutine = StartCoroutine(AttackRoutine());
    }
    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _canAttack = false;
        _hands.Play("PlayerPunch", 0, 0f);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius);
        foreach (Collider2D enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.takeDamage(_damage);
            }
            ZombieEnemyHealth zombieHealth = enemy.GetComponent<ZombieEnemyHealth>();
            if(zombieHealth != null)
            {
                zombieHealth.takeDamage(_damage);
            }
        }
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
        _isAttacking = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
    public void CancelAttack()
    {
        if (_attackRoutine != null)
            StopCoroutine(_attackRoutine);
        _canAttack = true;
        _isAttacking = false;
        _hands.Play("PlayerPunchIdle", 0, 0f);
    }
    public void FlipMeleeZone(bool isRight)
    {
        transform.localPosition = new Vector3(isRight ? _startPos.x : -_startPos.x, _startPos.y, _startPos.z);
    }
}
