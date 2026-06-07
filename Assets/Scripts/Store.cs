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
    public void ShowPrimary()
    {
        _currentPrimaryWeapon.SetActive(true);
        _currentSecondaryWeapon.SetActive(false);
        _primaryPanel.SetActive(true);
        _secondaryPanel.SetActive(false);
    }
    public void ShowSecondary()
    {
        _currentSecondaryWeapon.SetActive(true);
        _currentPrimaryWeapon.SetActive(false);
        _secondaryPanel.SetActive(true);
        _primaryPanel.SetActive(false);
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
