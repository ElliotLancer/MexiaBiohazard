using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class WeaponInventory : MonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private ChangeWeapon _currentWeapon;
    [SerializeField] private PlayerMelee _melee;
    [SerializeField] private WeaponUI _weaponUI;

    private List<int> _availableWeapons = new();
    private int _currentAvailableIndex = 0;
    private int _currentIndex = 0;
    private void Start()
    {
        string primaryWeapon = PlayerPrefs.GetString("PrimaryWeapon", "");

        string secondaryWeapon = PlayerPrefs.GetString("SecondaryWeapon", "pistol");

        bool hasPrimary = primaryWeapon == "shotgun" || primaryWeapon == "rifle";

        _weaponUI.slots[2].gameObject.SetActive(hasPrimary);

        _availableWeapons.Clear();

        _availableWeapons.Add(0);

        if (primaryWeapon == "shotgun")
            _availableWeapons.Add(1);

        if (primaryWeapon == "rifle")
            _availableWeapons.Add(2);

        _availableWeapons.Add(3);

        foreach (GameObject weapon in _weapons)
        {
            weapon.SetActive(false);
        }

        _currentAvailableIndex = 0;
        _currentIndex = _availableWeapons[_currentAvailableIndex];

        _weapons[_currentIndex].SetActive(true);

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

        _currentAvailableIndex++;

        if (_currentAvailableIndex >= _availableWeapons.Count)
            _currentAvailableIndex = 0;

        _currentIndex = _availableWeapons[_currentAvailableIndex];

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
            ChangeWeaponByIndex(3);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeaponByIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (_availableWeapons.Contains(1))
                ChangeWeaponByIndex(1);

            else if (_availableWeapons.Contains(2))
                ChangeWeaponByIndex(2);
        }
    }
}