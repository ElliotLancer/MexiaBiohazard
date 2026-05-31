using UnityEngine;

public class ZombieEnemyHealth : MonoBehaviour, IEnemyDeathHandler
{
    [SerializeField] private RemoveBackParts _remove;
    [SerializeField] private int _health = 70;
    [SerializeField] private ResetPose _resetPose;
    [SerializeField] private DamagePopup _popupPrefab;
    [SerializeField] private Vector3 _maxPopupRange;
    private string _name;
    public void takeDamage(int damage)
    {
        _health -= damage;
        Vector3 offset = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(_maxPopupRange.x, _maxPopupRange.y));
        DamagePopup popup = Instantiate(_popupPrefab, transform.position + offset, Quaternion.identity);
        popup.Setup(damage);
        _resetPose.Reset();
        if (_health <= 0)
        {
            GetComponent<EnemyZombieRagdoll>().EnableRagdoll();
        }
    }
    public void OnDeath()
    {
        if(_remove != null)
            _remove.Remove();
        int deadEnemyLayer = LayerMask.NameToLayer("DeadEnemy");
        SetLayerRecursively(gameObject, deadEnemyLayer);
        Debug.Log($"{_name} died");
    }
    private void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;

        foreach (Transform child in obj.transform)
        {
            if (child.CompareTag("Trigger"))
            {
                int triggerLayer = LayerMask.NameToLayer("Zone");
                child.gameObject.layer = triggerLayer;
            }
            else
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }
    }
}
