using System;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] _bodyParts;
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _rifleAnimator;
    [SerializeField] private Collider2D _mainCollider;
    [SerializeField] private Rigidbody2D _mainRb;
    private void Start()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        _animator.enabled = false;
        _rifleAnimator.enabled = false;
        foreach (Rigidbody2D bodypart in _bodyParts)
        {
            bodypart.bodyType = RigidbodyType2D.Dynamic;
            bodypart.simulated = true;
        }
        foreach (MonoBehaviour script in _scripts)
        {
            script.enabled = false;
        }
        _mainCollider.enabled = false;
        _mainRb.simulated = false;
    }
    public void DisableRagdoll()
    {
        foreach (Rigidbody2D bodypart in _bodyParts)
        {
            bodypart.bodyType = RigidbodyType2D.Dynamic;
            bodypart.simulated = false;
        }
        _mainRb.simulated = true;
        _mainCollider.enabled = true;
    }
}
