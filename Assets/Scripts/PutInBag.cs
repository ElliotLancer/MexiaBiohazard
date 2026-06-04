using TMPro;
using UnityEngine;

public class PutInBag : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    public Transform EnemyBody => _spawnPoint;
    public void Put()
    {
        Destroy(gameObject);
        Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
    }
}
