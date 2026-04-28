using Unity.VisualScripting;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] _parts;
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private Collider2D[] _partColliders;
    [SerializeField] private Rigidbody2D _mainRb;
    [SerializeField] private Collider2D _mainCollider;
    [SerializeField] private Animator _animator;
    private void Start()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        _animator.enabled = false;
        foreach(var script in _scripts)
        {
            script.enabled = false;
        }
        foreach(var rb in _parts)
        {
            rb.simulated = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        foreach(var collider in _partColliders)
        {
            collider.enabled = false;
        }
        _mainCollider.enabled = false;
        _mainRb.simulated = false;
    }
    public void DisableRagdoll()
    {
        _mainRb.simulated = true;
        _mainCollider.enabled = true;
        foreach (var collider in _partColliders)
        {
            collider.enabled = true;
        }
        foreach (var rb in _parts)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.simulated = false;
        }
    }
   
}
