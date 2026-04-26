using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _stopDistance = 1f;
    [SerializeField] private float _detectDistance = 10f;
    public bool canMove = true;
    private Animator _animator;
    private Transform _player;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInParent<Animator>();
    }
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            _player = playerObject.transform;
        }
    }
    private void Update()
    {
        if(_player.position.x > transform.position.x)
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
        if (distance > _stopDistance)
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
