using UnityEngine;

public class BodyTiilt : MonoBehaviour
{
    public Transform body;
    public Camera cam;

    [SerializeField] private float tiltAmount = 15f;

    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mouse - body.position;

        dir.Normalize();

        float tilt = dir.y * tiltAmount;

        body.rotation = Quaternion.Euler(0, 0, tilt);
    }
}
