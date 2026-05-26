using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public WeaponType currentWeaponType;

    [SerializeField] private Transform _shoulder;
    [SerializeField] private Transform _backShoulder;
    [SerializeField] private Transform _forearm;
    [SerializeField] private Transform _backForearm;
    [SerializeField] private Transform _hand;
    [SerializeField] private Transform _backHand;
    [SerializeField] private SpriteRenderer _handSprite;
    [SerializeField] private SpriteRenderer _backHandSprite;

    [SerializeField] private WeaponPose _pistolPose;
    [SerializeField] private WeaponPose _riflePose;
    [SerializeField] private WeaponPose _shotgunPose;
    [SerializeField] private WeaponPose _punchPose;
    [SerializeField] private GameObject _weaponArmPoint;
    [SerializeField] private GameObject _meleeCombat;
    [SerializeField] private WeaponUI _weaponUI;
    [SerializeField] private AmmoUI _ammoUI;
    [SerializeField] private Gun _currentGun;

    [SerializeField] private RectTransform _rect;
    public void ChangeGun()
    {
        GetCurrentWeapon();
        bool isHands = currentWeaponType == WeaponType.Hands;
        if (isHands)
        {
            _ammoUI.HideAmmoUI();
        }
        else
        {
            _ammoUI.ShowAmmoUI();
        }
        _meleeCombat.SetActive(isHands);

        _currentGun = _weaponArmPoint.GetComponentInChildren<Gun>();
        if (_currentGun != null)
            _ammoUI.SetWeapon(_currentGun);

        switch (currentWeaponType)
        {
            case WeaponType.Pistol:
                ApplyPose(_pistolPose);
                _weaponUI.weaponImage.sprite = _weaponUI.pistol;
                _weaponUI.ChangeSlot(0);
                _rect.sizeDelta = new Vector2(42, 31);
                break;
            case WeaponType.Rifle:
                ApplyPose(_riflePose);
                _weaponUI.weaponImage.sprite = _weaponUI.rifle;
                _weaponUI.ChangeSlot(1);
                _rect.sizeDelta = new Vector2(89, 31);
                break;
            case WeaponType.Shotgun:
                ApplyPose(_shotgunPose);
                _weaponUI.weaponImage.sprite = _weaponUI.shotgun;
                _weaponUI.ChangeSlot(1);
                _rect.sizeDelta = new Vector2(89, 31);
                break;
            default:
                ApplyPose(_punchPose);
                _weaponUI.weaponImage.sprite = _weaponUI.hands;
                _weaponUI.ChangeSlot(2);
                _rect.sizeDelta = new Vector2(42, 31);
                break;
        }
    }
    private void Awake()
    {
        GetCurrentWeapon();
    }
    private void ApplyPose(WeaponPose pose)
    {
        _shoulder.localRotation = Quaternion.Euler(pose.shoulderRotation);
        _backShoulder.localRotation = Quaternion.Euler(pose.backShoulderRotation);
        _hand.localRotation = Quaternion.Euler(pose.handRotation);
        _backHand.localRotation = Quaternion.Euler(pose.backHandRotation);
        _forearm.localRotation = Quaternion.Euler(pose.forearmRotation);
        _backForearm.localRotation = Quaternion.Euler(pose.backForearmRotation);
        _handSprite.sprite = pose.fist;
        _backHandSprite.sprite = pose.backFist;
    }
    private void GetCurrentWeapon()
    {
        Weapon weapon = _weaponArmPoint.GetComponentInChildren<Weapon>();
        currentWeaponType = weapon != null ? weapon.weapon : WeaponType.Hands;
    }
}
