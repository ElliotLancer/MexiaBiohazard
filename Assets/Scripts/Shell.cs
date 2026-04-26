using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float destroyTime = 4f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
