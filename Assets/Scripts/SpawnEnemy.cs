using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _leftPrefab;
    [SerializeField] private GameObject _rightPrefab;
    [SerializeField] private Transform _player;

    private GameObject _currentWasp;
    private bool _currentFacingLeft;

    private void Start()
    {
        SpawnCorrectWasp();
    }

    private void Update()
    {
        if (_player == null || _currentWasp == null)
            return;

        bool shouldFaceLeft = _player.position.x < transform.position.x;

        if (shouldFaceLeft != _currentFacingLeft)
        {
            Destroy(_currentWasp);
            SpawnCorrectWasp();
        }
    }

    private void SpawnCorrectWasp()
    {
        bool shouldFaceLeft = _player.position.x < transform.position.x;

        GameObject prefab = shouldFaceLeft ? _leftPrefab : _rightPrefab;

        _currentWasp = Instantiate(prefab, transform.position, Quaternion.identity);
        _currentFacingLeft = shouldFaceLeft;
    }


}
