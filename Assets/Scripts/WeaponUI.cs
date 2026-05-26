using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image weaponImage;
    public Sprite pistol;
    public Sprite rifle;
    public Sprite shotgun;
    public Sprite hands;
    public Image[] slots;
    public Color mainSlotColor;
    public Color graySlotColor;
    private int _currentIndex;

    public void ChangeSlot(int index)
    {
        _currentIndex = index;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == _currentIndex)
            {
                slots[i].color = mainSlotColor;
            }
            else
            {
                slots[i].color = graySlotColor;
            }
        }
    }
}
