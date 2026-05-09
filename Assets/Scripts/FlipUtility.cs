using UnityEngine;

public static class FlipUtility
{
    public static void FlipYRotation(Transform obj, Transform target)
    {
        Vector3 rot = obj.eulerAngles;

        rot.y = target.position.x < obj.position.x ? 0 : 180;

        obj.eulerAngles = rot;
    }
    public static bool IsOnRight(Transform obj, Transform target)
    {
        return target.position.x > obj.position.x;
    }
}
