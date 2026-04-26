using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private int _speed = 4;
    public float offsetX = 1;
    public float offsetY = 1;
    private void LateUpdate()
    {
        if (_target == null)
            return;
        Vector3 targetPossition = new Vector3(_target.position.x * offsetX, _target.position.y * offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPossition, _speed * Time.deltaTime);
    }
}
