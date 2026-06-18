using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private int _minAmmoAmount;
    [SerializeField] private int _maxAmmoAmount;
    private int _ammoAmount;
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private AudioClip _audioClip;
    private void Start()
    {
        int finalAmount = Random.Range(_minAmmoAmount, _maxAmmoAmount);
        _ammoAmount = finalAmount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Trigger"))
            return;
        Gun[] guns = collision.transform.root.GetComponentsInChildren<Gun>(true);
        foreach (Gun gun in guns)
        {
            if (_ammoType == AmmoType.Pistol &&
            gun.CurrentWeaponType.weapon == WeaponType.Pistol)
            {
                gun.AddAmmo(_ammoAmount);
                break;
            }

            if (_ammoType == AmmoType.Rifle &&
                gun.CurrentWeaponType.weapon == WeaponType.Rifle)
            {
                gun.AddAmmo(_ammoAmount);
                break;
            }

            if (_ammoType == AmmoType.Shotgun &&
                gun.CurrentWeaponType.weapon == WeaponType.Shotgun)
            {
                gun.AddAmmo(_ammoAmount);
                break;
            }
        }
        AudioManager.Instance.Play(_audioClip);
        Destroy(gameObject);
    }
}
