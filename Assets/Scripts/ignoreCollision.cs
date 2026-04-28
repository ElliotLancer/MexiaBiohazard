using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    private void Awake()
    {
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i + 1; j < colliders.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[j], true);
            }
        }
    }
}
