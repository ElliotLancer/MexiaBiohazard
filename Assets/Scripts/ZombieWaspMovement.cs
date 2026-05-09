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
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private bool _canMove = true;
    private bool _isOnRight;
    private HingeFlip _hinge;
    private bool _canShoot = true;
    private Coroutine _shootRoutine;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hinge = GetComponent<HingeFlip>();
    }
    private void Start()
    {
        _shootRoutine = StartCoroutine(Shoot());
        _isOnRight = _targetPoint.position.x > transform.position.x ? true : false;
    }
    private void Update()
    {
        FlipUtility.FlipYRotation(transform, _targetPoint);
        bool isRight = FlipUtility.IsOnRight(transform, _targetPoint);
        if ( isRight != _isOnRight)
        {
            _isOnRight = isRight;
            _hinge.Flip();
        }
    }
    private void FixedUpdate()
    {
        if (_targetPoint == null || !_canMove)
        {
            Stop();
            return;
        }
        float distance = Vector2.Distance(transform.position, _targetPoint.position);
        if (distance > _detectDistance)
        {
            Stop();
            _canShoot = false;
            return;
        }
        if (distance > _stopDistance)
        {
            Vector2 direction = (_targetPoint.position - transform.position).normalized;
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
            if (_targetPoint != null && _canMove && _canShoot)
            {
                GameObject projectileObject = Instantiate(_prefab, _firePoint.position, Quaternion.identity);

                EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();

                if (projectile != null)
                {
                    Vector2 dir = (_targetPoint.position - _firePoint.position).normalized;
                    Debug.DrawRay(_firePoint.position, dir * 5f, Color.red, 1f);
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
    public void SetTargetPoint(Transform target)
    {
        _targetPoint = target;
    }
}

