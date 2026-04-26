using UnityEngine;

public class ignoreCollision : MonoBehaviour
{
    [SerializeField] private Collider2D _body;
    [SerializeField] private Collider2D _arm;
    [SerializeField] private Collider2D _arm1;
    [SerializeField] private Collider2D _leg;
    [SerializeField] private Collider2D _leg1;
    [SerializeField] private Collider2D _head;

    private void Start()
    {
        Physics2D.IgnoreCollision(_body, _arm);
        Physics2D.IgnoreCollision(_body, _arm1);
        Physics2D.IgnoreCollision(_body, _leg1);
        Physics2D.IgnoreCollision(_head, _body);
        Physics2D.IgnoreCollision(_head, _arm);
        Physics2D.IgnoreCollision(_head, _arm1);
        Physics2D.IgnoreCollision(_arm1, _leg);
        Physics2D.IgnoreCollision(_arm1, _leg1);
    }
}
