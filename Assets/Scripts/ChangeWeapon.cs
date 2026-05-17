using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private WeaponType currentWeaponType;

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
    [SerializeField] private HandSprites _sprite;
    private void Awake()
    {
        Weapon weapon = _weaponArmPoint.GetComponentInChildren<Weapon>();
        currentWeaponType =  weapon != null ? weapon.weapon : WeaponType.Hands;
    }
    private void Update()
    {
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
                _handSprite.sprite = _sprite.fist;
                _backHandSprite.sprite = _sprite.backFist;
                break;
        }
    }
    private void ApplyPose(WeaponPose pose)
    {
        _shoulder.localRotation = Quaternion.Euler(pose.shoulderRotation);
        _backShoulder.localRotation = Quaternion.Euler(pose.backShoulderRotation);
        _hand.localRotation = Quaternion.Euler(pose.handRotation);
        _backHand.localRotation = Quaternion.Euler(pose.backHandRotation);
        _forearm.localRotation = Quaternion.Euler(pose.forearmRotation);
        _backForearm.localRotation = Quaternion.Euler(pose.backForearmRotation);

    }
}
