using System.Collections;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _arm;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;

    [SerializeField] private float _headTiltPower = 52f;
    [SerializeField] private float _minHeadAngle = 21f;
    [SerializeField] private float _maxHeadAngle = 90f;

    private HingeFlip _hinge;

    private bool _playerFacingRight;
    private bool _mouseFacingRight;
    private bool _canFlip;
    public bool IsFacingRight => _playerFacingRight;

    private IEnumerator Start()
    {
        _body.localScale = Vector3.one;
        _playerFacingRight = true;
        _hinge = GetComponent<HingeFlip>();
        yield return null;
        _canFlip = true;
    }
    private void Update()
    {
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        _body.localScale = mousePosition.x > transform.position.x ? Vector3.one : new Vector3(-1, 1, 1);

        _mouseFacingRight = mousePosition.x > transform.position.x;

        if (_canFlip && _mouseFacingRight != _playerFacingRight)
        {
            _playerFacingRight = _mouseFacingRight;
            _hinge.Flip();
        }

        Vector3 dir = mousePosition - _arm.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (_body.localScale.x < 0)
        {
            angle += 180f;
        }
        
        _arm.rotation = Quaternion.Euler(0, 0, angle);

        Vector3 headDir = mousePosition - _head.position;
        headDir.Normalize();

        float headAngle = headDir.y * _headTiltPower;

        headAngle = Mathf.Clamp(headAngle, _minHeadAngle, _maxHeadAngle);

        _head.localRotation = Quaternion.Euler(0, 0, headAngle);
    }
}
