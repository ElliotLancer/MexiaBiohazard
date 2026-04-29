using UnityEngine;

public class Kill : MonoBehaviour
{
    public PlayerHealth health;
    public ZombieEnemyHealth health2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            health.Die();
            health2.Die();
        }
    }
}
