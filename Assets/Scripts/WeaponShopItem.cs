using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopItem : MonoBehaviour
{
    public int Price => _price;
    public bool Owned => _owned;
    public bool Equiped => _equiped;
    public string WeaponName => _weaponName;
    public string WeaponId => _weaponId;
    public Sprite WeaponSprite => _weaponSprite;
    public Vector2 WeaponSize => _widthAndHeight;

    [SerializeField] private ShopWeaponType _weaponType;
    [SerializeField] private Vector2 _widthAndHeight;
    [SerializeField] private Store _store;
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private int _price;
    [SerializeField] private bool _owned;
    [SerializeField] private string _weaponName;
    [SerializeField] private string _weaponId;
    private bool _equiped;
    private void Awake()
    {
        _owned = PlayerPrefs.GetInt(_weaponId + "_Owned", _owned ? 1 : 0) == 1;
        _equiped = PlayerPrefs.GetInt(_weaponId + "_Equipped", 0) == 1;
        string secondaryWeaponId = PlayerPrefs.GetString("SecondaryWeapon", "");
        if (_weaponId == secondaryWeaponId)
            _equiped = true;
    }
    public void OnClickPrimary()
    {
        _store.SelectPrimaryWeapon(this);
        _store.ChangePrimaryWeapon(_weaponSprite, _widthAndHeight);
    }
    public void OnClickSecondary()
    {
        _store.SelectSecondaryWeapon(this);
        _store.ChangeSecondaryWeapon(_weaponSprite, _widthAndHeight);
    }
    public void OnButtonClick()
    {
        if (!_owned)
        {
            Buy();
        }
        else
        {
            Equip();
        }
    }
    private void Buy()
    {
        if (PlayerData.coins < _price)
            return;
        PlayerData.coins -= _price;
        _owned = true;
        PlayerPrefs.SetInt("Coins", PlayerData.coins);
        PlayerPrefs.SetInt(_weaponId + "_Owned", 1);
        PlayerPrefs.Save();
    }
    private void Equip()
    {
        if (!_equiped)
        {
            if (_weaponType == ShopWeaponType.Primary)
            {
                _store.UnequipAllPrimary();

                PlayerPrefs.SetString("PrimaryWeapon", _weaponId);

                _store.SelectPrimaryWeapon(this);
            }
            else
            {
                _store.UnequipAllSecondary();

                PlayerPrefs.SetString("SecondaryWeapon", _weaponId);

                _store.SelectSecondaryWeapon(this);
            }
            _equiped = true;
            PlayerPrefs.SetInt(_weaponId + "_Equipped", 1);
        }
        else
        {
            _equiped = false;
            PlayerPrefs.SetInt(_weaponId + "_Equipped", 0);
        }

        PlayerPrefs.Save();
    }
    public void SetEquipped(bool value)
    {
        _equiped = value;
        PlayerPrefs.SetInt(WeaponId + "_Equipped", _equiped ? 1 : 0);
        PlayerPrefs.Save();
    }
}
