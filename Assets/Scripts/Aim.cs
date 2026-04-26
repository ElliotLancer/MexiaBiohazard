using UnityEngine;
using UnityEngine.InputSystem;

public class Aim : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _arm;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform body;
    [SerializeField] private float _headTiltPower = 10f;
    [SerializeField] private float _minHeadAngle = 0.4f;
    [SerializeField] private float _maxHeadAngle = 0.4f;


    private void Update()
    {
        Vector3 mousePosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (mousePosition.x > transform.position.x)
        {
            body.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            body.localScale = new Vector3(-1, 1, 1);
        }

        Vector3 dir = mousePosition - _arm.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (body.localScale.x < 0)
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
