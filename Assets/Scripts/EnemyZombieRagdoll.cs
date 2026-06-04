using System;
using UnityEngine;

public class EnemyZombieRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _mainRigidbody;
    [SerializeField] private Collider2D _mainCollider;

    [SerializeField] private Rigidbody2D[] _bodyPartRigidbody;
    [SerializeField] private Collider2D[] _bodyPartColliders;
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _enemyInteractZone;
    private void Start()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        _mainRigidbody.simulated = false;
        _mainCollider.enabled = false;
        _animator.enabled = false;
        _enemyInteractZone.enabled = true;
        IEnemyDeathHandler[] enemies = GetComponents<IEnemyDeathHandler>();
        foreach(IEnemyDeathHandler enemy in enemies)
        {
            enemy.OnDeath();
        }
        foreach(Rigidbody2D rb in _bodyPartRigidbody)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.simulated = true;
        }
        foreach(MonoBehaviour script in _scripts)
        {
            script.enabled = false;
        }
        foreach (Collider2D collider in _bodyPartColliders)
        {
            collider.isTrigger = false;
        }
    }
    private void DisableRagdoll()
    {
        _mainRigidbody.simulated = true;
        _mainCollider.enabled = true;
        _animator.enabled = true;
        _enemyInteractZone.enabled = false;

        foreach (Rigidbody2D rb in _bodyPartRigidbody)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = true;
        }
        foreach(Collider2D collider in _bodyPartColliders)
        {
            collider.isTrigger = true;
        }
    }
}
