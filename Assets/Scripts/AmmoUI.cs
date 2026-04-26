using UnityEngine;
using TMPro;
public class AmmoUI : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private TMP_Text _ammoText;

    private void Update()
    {
        if (_gun == null)
            return;
        _ammoText.text = _gun.CurrentAmmo + "/" + _gun.MaxAmmo;
    }
}
