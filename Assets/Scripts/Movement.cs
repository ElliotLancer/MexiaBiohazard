using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Vector2 _crouchSize = new Vector2(1.13f, 3.7f);
    [SerializeField] private Vector2 _crouchOffset = new Vector2(0f, -0.25f);

    private Vector2 _standSize;
    private Vector2 _standOffset;
    private Rigidbody2D _rb;
    private float _moveInput;
    public Animator animator;
    private bool _isCrouching = false;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _standSize = _collider.size;
        _standOffset = _collider.offset;
    }
    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        float speed = Mathf.Abs(_moveInput);
        animator.SetFloat("Speed", speed);
        _isCrouching = Input.GetKey(KeyCode.LeftControl);
        if (_isCrouching)
        {
            _collider.size = _crouchSize;
            _collider.offset = _crouchOffset;
        }
        else
        {
            _collider.size = _standSize;
            _collider.offset = _standOffset;
        }
        animator.SetBool("IsCrouching", _isCrouching);
    }
    private void FixedUpdate()
    {
        float speed = _isCrouching ? _crouchSpeed : _movementSpeed;
        _rb.linearVelocity = new Vector2(_moveInput * speed, _rb.linearVelocity.y);
    }

}
