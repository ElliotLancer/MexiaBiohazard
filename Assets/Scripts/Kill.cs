using UnityEngine;

public class Kill : MonoBehaviour
{
    public PlayerHealth health;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            health.Die();
        }
    }
}
