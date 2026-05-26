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
    public void ChangeGun()
    {
        GetCurrentWeapon();
        switch (currentWeaponType)
        {
            case WeaponType.Pistol:
                ApplyPose(_pistolPose);
                break;
            case WeaponType.Rifle:
                ApplyPose(_riflePose);
                break;
            case WeaponType.Shotgun:
                ApplyPose(_shotgunPose);
                break;
            default:
                ApplyPose(_punchPose);
                break;
        }
    }
    private void Awake()
    {
        GetCurrentWeapon();
    }
    private void Update()
    {
        ChangeGun();
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
