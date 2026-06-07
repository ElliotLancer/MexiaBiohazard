using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private Vector2 _widthAndHeight;
    [SerializeField] private Store _store;

    public void OnClickPrimary()
    {
        _store.ChangePrimaryWeapon(_weaponSprite, _widthAndHeight);
    }
    public void OnClickSecondary()
    {
        _store.ChangeSecondaryWeapon(_weaponSprite, _widthAndHeight);
    }
}
