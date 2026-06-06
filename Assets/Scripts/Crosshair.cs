using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    private Camera _cam;
    public Vector3 offset;

    private void Start()
    {
        _cam = Camera.main;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos + offset;
    }
}
