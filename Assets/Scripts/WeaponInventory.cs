using Unity.VisualScripting;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private ChangeWeapon _currentWeapon;
    private int _currentIndex = 0;
    private void Start()
    {
        _currentIndex = ((int)_currentWeapon.currentWeaponType);
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].SetActive(i == _currentIndex);
        }
        Debug.Log(_currentIndex);
    }
    public void ChangeWeaponByQueue()
    {
        _weapons[_currentIndex].SetActive(false);
        _currentIndex++;

        if (_currentIndex >= _weapons.Length)
            _currentIndex = 0;
        _weapons[_currentIndex].SetActive(true);
    }
    private void ChangeWeaponByIndex(int index)
    {
        if (index < 0 || index >= _weapons.Length)
            return;
        _weapons[_currentIndex].SetActive(false);
        _currentIndex = index;
        _weapons[_currentIndex].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeaponByQueue();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeaponByIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeaponByIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeaponByIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeWeaponByIndex(3);
    }
}