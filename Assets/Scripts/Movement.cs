using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rb;
    private float _moveInput;
    public Animator animator;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        float speed = Mathf.Abs(_moveInput);
        animator.SetFloat("Speed", speed);
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput * _movementSpeed, _rb.linearVelocity.y);
    }

}
