using UnityEngine;

public class EnemyHitBoxRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] _rigidbodies;
    [SerializeField] private MonoBehaviour[] _scripts;

    private void Start()
    {
        DisableRagdoll();
    }
    public void EnableRagdoll()
    {
        foreach(Rigidbody2D rb in _rigidbodies)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        foreach(MonoBehaviour script in _scripts)
        {
            script.enabled = false;
        }
    }
    private void DisableRagdoll()
    {
        foreach(Rigidbody2D rb in _rigidbodies)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
