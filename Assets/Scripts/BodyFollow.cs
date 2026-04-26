using UnityEngine;

public class BodyFollow : MonoBehaviour
{
    public Transform body;
    public Camera cam;
    public float percentage = 0.3f;

    void Update()
    {
        Vector3 mouse = cam.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0f;

        Vector3 dir = mouse - body.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // нормализуем угол
        angle = Mathf.DeltaAngle(0, angle);

        // ограничиваем наклон тела
        angle = Mathf.Clamp(angle, -90f, 90f);

        // тело поворачивается частично
        angle *= percentage;

        body.rotation = Quaternion.Euler(0, 0, angle);
    }
}
