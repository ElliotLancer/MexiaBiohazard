using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _stopDistance = 1f;
    [SerializeField] private float _detectDistance = 10f;
    private HingeFlip _hinge;
    private bool _isOnRight;
    public bool canMove = true;
    private Animator _animator;
    private Transform _player;
    private Rigidbody2D _rb;
    private PlayerHealth _playerHealth;
    private bool _canFlip;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();
        _hinge = GetComponent<HingeFlip>();
    }
    private IEnumerator Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            _player = playerObject.transform;

        PlayerHealth playerHealth = playerObject.GetComponentInParent<PlayerHealth>();
        if (playerHealth != null)
            _playerHealth = playerHealth;
        _isOnRight = false;
        yield return new WaitForSeconds(0.1f);
        _canFlip = true;
    }
    private void Update()
    {
        FlipUtility.FlipYRotation(transform, _player);
        bool isRight = FlipUtility.IsOnRight(transform, _player);
        if (_canFlip && isRight != _isOnRight)
        {
            _isOnRight = isRight;
            _hinge.Flip();
        }
    }
    private void FixedUpdate()
    {
        if (_player == null || !canMove)
        {
            Stop();
            return;
        }
        float distance = Vector2.Distance(transform.position, _player.position);
        if (distance > _detectDistance)
        {
            Stop();
            return;
        }
        if (distance > _stopDistance && _playerHealth.IsAlive)
        {
            Vector2 direction = (_player.position - transform.position).normalized;
            _rb.linearVelocity = new Vector2(direction.x * _speed, _rb.linearVelocity.y);

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
}
