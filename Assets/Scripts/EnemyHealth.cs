using System.Runtime.Serialization;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 70;
    [SerializeField] private DamagePopup _popupPrefab;
    private string _name;
    public void takeDamage(int damage)
    {
        _health -= damage;
        Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(1.5f, 2f));
        DamagePopup popup = Instantiate(_popupPrefab, transform.position + offset, Quaternion.identity);
        popup.Setup(damage);
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
