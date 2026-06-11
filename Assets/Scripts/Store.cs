using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private Image _currentPrimaryWeaponImage;
    [SerializeField] private GameObject _currentPrimaryWeapon;
    [SerializeField] private RectTransform _primaryRect;

    [SerializeField] private Image _currentSecondaryWeaponImage;
    [SerializeField] private GameObject _currentSecondaryWeapon;
    [SerializeField] private RectTransform _secondaryRect;

    [SerializeField] private GameObject _primaryPanel;
    [SerializeField] private GameObject _secondaryPanel;

    [SerializeField] private WeaponShopItem _selectedWeapon;
    [SerializeField] private WeaponShopItem _selectedPrimaryWeapon;
    [SerializeField] private WeaponShopItem _selectedSecondaryWeapon;
    [SerializeField] private WeaponShopItem _defaultSecondaryWeapon;

    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private TMP_Text _weaponName;
    [SerializeField] private WeaponShopItem[] _primaryWeapons;

    private void Start()
    {
        _selectedSecondaryWeapon = _defaultSecondaryWeapon;

        _defaultSecondaryWeapon.OnClickSecondary();

        PlayerData.coins = PlayerPrefs.GetInt("Coins", 0);

        string primaryWeaponId = PlayerPrefs.GetString("PrimaryWeapon", "");

        foreach (WeaponShopItem weapon in _primaryWeapons)
        {
            if (weapon.WeaponId == primaryWeaponId)
            {
                _selectedPrimaryWeapon = weapon;
                break;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("Prefs deleted");
        }
    }
    public void SelectPrimaryWeapon(WeaponShopItem weapon)
    {
        _selectedPrimaryWeapon = weapon;
        _selectedWeapon = weapon;
        ChangePrimaryWeapon(
        weapon.WeaponSprite,
        weapon.WeaponSize);
        UpdateSelectedWeaponUI();
    }
    public void SelectSecondaryWeapon(WeaponShopItem weapon)
    {
        _selectedSecondaryWeapon = weapon;
        _selectedWeapon = weapon;
        ChangeSecondaryWeapon(
        weapon.WeaponSprite,
        weapon.WeaponSize);
        UpdateSelectedWeaponUI();
    }
    public void UpdateSelectedWeaponUI()
    {
        if (_selectedWeapon == null)
        {
            _weaponName.text = "none";
            _buttonText.text = "no weapon";
            return;
        }
        _weaponName.text = _selectedWeapon.WeaponName;

        if (!_selectedWeapon.Owned)
        {
            _priceText.text = _selectedWeapon.Price + "$";
            _buttonText.text = "Buy";
        }
        else
        {
            _priceText.text = "";
            _buttonText.text =
                _selectedWeapon.Equiped
                ? "Unequip"
                : "Equip";
        }
        Debug.Log(
            _selectedWeapon.WeaponName +
            " Owned=" + _selectedWeapon.Owned +
            " Equipped=" + _selectedWeapon.Equiped);
    }
    public void BuyCurrentWeapon()
    {
        if (_selectedWeapon != null)
        {
            _selectedWeapon.OnButtonClick();
            UpdateSelectedWeaponUI();
        }
    }
    public void ShowPrimary()
    {
        _currentPrimaryWeapon.SetActive(true);
        _currentSecondaryWeapon.SetActive(false);
        _primaryPanel.SetActive(true);
        _secondaryPanel.SetActive(false);
        if (_selectedPrimaryWeapon != null)
        {
            _selectedPrimaryWeapon.OnClickPrimary();
        }
        else
        {
            _selectedWeapon = null;
            UpdateSelectedWeaponUI();
        }
    }
    public void ShowSecondary()
    {
        _currentSecondaryWeapon.SetActive(true);
        _currentPrimaryWeapon.SetActive(false);
        _secondaryPanel.SetActive(true);
        _primaryPanel.SetActive(false);
        _selectedWeapon = _selectedSecondaryWeapon;
        UpdateSelectedWeaponUI();
    }
    public void ChangePrimaryWeapon(Sprite sprite, Vector2 rect)
    {
        _currentPrimaryWeaponImage.sprite = sprite;
        _primaryRect.sizeDelta = rect;
    }
    public void ChangeSecondaryWeapon(Sprite sprite, Vector2 rect)
    {
        _currentSecondaryWeaponImage.sprite = sprite;
        _secondaryRect.sizeDelta = rect;
    }
}
