using TMPro;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopItem : MonoBehaviour
{
    public int Price => _price;
    public bool Owned => _owned;
    public bool Equiped => _equiped;

    [SerializeField] private Vector2 _widthAndHeight;
    [SerializeField] private Store _store;
    [SerializeField] private Sprite _weaponSprite;
    
    [SerializeField] private int _price;
    [SerializeField] private bool _owned = false;
    private bool _equiped = false;
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
    }
    private void Equip()
    {
        _equiped = !_equiped;
    }
}
