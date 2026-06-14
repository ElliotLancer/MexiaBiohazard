using TMPro;
using UnityEngine;

public class PutInBag : MonoBehaviour
{
    [SerializeField] private GameObject _bagPrefab;
    [SerializeField] private SpawnItems _money;
    [SerializeField] private Transform _spawnPoint;
    public Transform EnemyBody => _spawnPoint;
    public void Put()
    {
        Destroy(gameObject);
        Instantiate(_bagPrefab, _spawnPoint.position, Quaternion.identity);
        _money.Spawn(_spawnPoint);
    }
}
