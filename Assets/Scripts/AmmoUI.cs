using UnityEngine;
using TMPro;
using System.Diagnostics;
public class AmmoUI : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private TMP_Text _ammoText;
    private bool isHands;
    public void SetWeapon(Gun gun)
    {
        _gun = gun;
    }
    public void HideAmmoUI()
    {
        isHands = true;
    }
    public void ShowAmmoUI()
    {
        isHands = false;
    }
    private void Update()
    {
        if (_gun == null)
        {
            _ammoText.enabled = false;
            return;
        }
        if (isHands)
        {
            _ammoText.text = " ";
        }
        else
        {
            _ammoText.text = _gun.CurrentAmmo + "/" + _gun.ReserveAmmo;
        }
    }
}
