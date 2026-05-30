using Unity.VisualScripting;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private ChangeWeapon _currentWeapon;
    [SerializeField] private PlayerMelee _melee;
    private int _currentIndex = 0;
    private void Start()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i].activeSelf)
            {
                _currentIndex = i;
                break;
            }
        }
        Debug.Log(_currentIndex);
        _currentWeapon.ChangeGun();
    }
    public void ChangeWeaponByQueue()
    {
        Gun gun = _weapons[_currentIndex].GetComponent<Gun>();

        if (gun != null)
        {
            gun.CancelReload();
            gun.SetAnimationToIdle();
            _melee.CancelAttack();
        }

        _weapons[_currentIndex].SetActive(false);

        _currentIndex++;

        if (_currentIndex >= _weapons.Length)
            _currentIndex = 0;

        _weapons[_currentIndex].SetActive(true);

        _currentWeapon.ChangeGun();
    }
    private void ChangeWeaponByIndex(int index)
    {
        if (index < 0 || index >= _weapons.Length)
            return;

        Gun gun = _weapons[_currentIndex].GetComponent<Gun>();

        if (gun != null)
        {
            gun.CancelReload();
            gun.SetAnimationToIdle();
            _melee.CancelAttack();
        }

        _weapons[_currentIndex].SetActive(false);

        _currentIndex = index;

        _weapons[_currentIndex].SetActive(true);

        _currentWeapon.ChangeGun();
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