using UnityEngine;
using TMPro;
public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    public void AddCoins (int amount)
    {
        PlayerData.coins += amount;
    }
    private void Update()
    {
        _moneyText.text = $"{PlayerData.coins}";
    }
}
