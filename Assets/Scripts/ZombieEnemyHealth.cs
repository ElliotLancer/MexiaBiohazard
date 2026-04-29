using UnityEngine;

public class ZombieEnemyHealth : MonoBehaviour
{
    [SerializeField] private RemoveBackParts _remove;
    [SerializeField] private int _health = 70;
    private string _name;
    public void takeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"{_name} {damage} damage");
        if (_health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GetComponent<EnemyHitBoxRagdoll>().EnableRagdoll();
        int deadEnemyLayer = LayerMask.NameToLayer("DeadEnemy");
        _remove.Remove();
        SetLayerRecursively(gameObject, deadEnemyLayer);
        Debug.Log($"{_name} died");
    }
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }
}
