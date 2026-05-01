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
    private void Start()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        _mainRigidbody.simulated = false;
        _mainCollider.enabled = false;
        _animator.enabled = false;

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

        foreach(Rigidbody2D rb in _bodyPartRigidbody)
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
