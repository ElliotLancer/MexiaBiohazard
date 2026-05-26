using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius = 1f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _damage = 8;
    private bool _canAttack;
    private void Update()
    {
        if (Input.GetMouseButton(0) && _canAttack)
        {
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Attack()
    {
        _canAttack = false;
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
    }
    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }
}
