using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 13f;
    [SerializeField] private float _lifeTime = 3f;
    [SerializeField] private int _damage = 10;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Weapon") || other.gameObject.layer == LayerMask.NameToLayer("DeadEnemy")) 
            return;
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            enemy.takeDamage(_damage);
        }
        
        Destroy(gameObject);
    }
}


