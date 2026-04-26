using System.Runtime.Serialization;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 70;
    private string _name = "CartMonster";
    public void takeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"{_name} - took {damage} damage");
        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        GetComponent<EnemyRagdoll>().EnableRagdoll();
        int deadEnemyLayer = LayerMask.NameToLayer("DeadEnemy");
        SetLayerRecursively(gameObject, deadEnemyLayer);
        Debug.Log("enemy died");
    }
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach(Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, layer);
        }
    }
    
}
