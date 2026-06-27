using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] _parts;
    [SerializeField] private MonoBehaviour[] _scripts;
    [SerializeField] private Rigidbody2D _mainRb;
    [SerializeField] private Collider2D _mainCollider;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _enemyInteractZone;
    private void Awake()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        _animator.enabled = false;
        _enemyInteractZone.enabled = true;
        foreach (MonoBehaviour script in _scripts)
        {
            script.enabled = false;
        }
        foreach (Rigidbody2D rb in _parts)
        {
            rb.simulated = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        _mainCollider.enabled = false;
        _mainRb.simulated = false;
    }
    public void DisableRagdoll()
    {
        _mainRb.simulated = true;
        _mainCollider.enabled = true;
        _enemyInteractZone.enabled = false;
        foreach (Rigidbody2D rb in _parts)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = false;
        }
    }
   
}
