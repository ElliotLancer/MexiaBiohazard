using UnityEngine;
using UnityEngine.Rendering;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 70;
    [SerializeField] private DamagePopup _popupPrefab;
    [SerializeField] private SortingGroup _sorting;
    private EnemyRagdoll _enemyRagdoll;
    private void Awake()
    {
        _enemyRagdoll = GetComponent<EnemyRagdoll>();
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        _health = Mathf.Max(0, _health);
        Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(1.5f, 2f));
        DamagePopup popup = Instantiate(_popupPrefab, transform.position + offset, Quaternion.identity);

        popup.Setup(damage);

        if (_health == 0)
            Die();
    }
    private void Die()
    {
        _enemyRagdoll.EnableRagdoll();
        int deadEnemyLayer = LayerMask.NameToLayer("DeadEnemy");
        _sorting.sortingLayerName = "DeadEnemy";
        _sorting.sortingOrder = 1;
        SetLayerRecursively(gameObject, deadEnemyLayer);
    }
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach(Transform child in obj.transform)
        {
            if (child.CompareTag("Trigger"))
            {
                int triggerLayer = LayerMask.NameToLayer("EnemyInteractZone");
                child.gameObject.layer = triggerLayer;
            }
            else
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }
    }
    
}
