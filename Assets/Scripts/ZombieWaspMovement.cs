using System.Collections;
using UnityEngine;

public class ZombieWaspMovement : MonoBehaviour, IEnemyDeathHandler
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _stopDistance = 1f;
    [SerializeField] private float _detectDistance = 10f;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 2f;
    [SerializeField] private Animator _animator;
    private bool _canMove = true;
    private bool _canShoot = true;
    private Transform _player;
    private Coroutine _shootRoutine;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            _player = playerObject.transform;
        }
        _shootRoutine = StartCoroutine(Shoot());
    }
    private void Update()
    {
        if (_player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void FixedUpdate()
    {
        if (_player == null || !_canMove)
        {
            Stop();
            return;
        }
        float distance = Vector2.Distance(transform.position, _player.position);
        if (distance > _detectDistance)
        {
            Stop();
            _canShoot = false;
            return;
        }
        if (distance > _stopDistance)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.linearVelocity = new Vector2(direction.x * _speed, _rb.linearVelocity.y);
            _canShoot = true;
        }
        else
        {
            Stop();
        }
        _animator.SetFloat("Speed", Mathf.Abs(_rb.linearVelocity.x));
    }
    private void Stop()
    {
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);
        _animator.SetFloat("Speed", 0);
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            if (_player != null && _canMove && _canShoot)
            {
                GameObject projectileObject = Instantiate(_prefab, _firePoint.position, Quaternion.identity);

                EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();

                if (projectile != null)
                {
                    Vector2 dir = (_player.position - _firePoint.position).normalized;
                    projectile.Shoot(dir);
                }
            }

            yield return new WaitForSeconds(_fireRate);
        }
    }
    public void OnDeath()
    {
        if (_shootRoutine != null)
            StopCoroutine(_shootRoutine);
    }
}

