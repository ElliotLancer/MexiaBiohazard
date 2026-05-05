using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private int _damage = 10;

    [SerializeField] private Rigidbody2D _rb;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    public void Shoot(Vector3 direction)
    {
        _rb.linearVelocity = direction * _speed;
        _rb.angularVelocity = 0f;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }


}
