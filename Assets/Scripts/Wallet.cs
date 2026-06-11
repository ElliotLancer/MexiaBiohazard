using UnityEngine;
using TMPro;
public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    public void AddCoins (int amount)
    {
        PlayerData.coins += amount;
        PlayerPrefs.SetInt("Coins", PlayerData.coins);
        PlayerPrefs.Save();
    }
    private void Start()
    {
        PlayerData.coins = PlayerPrefs.GetInt("Coins", 0);
    }
    private void Update()
    {
        _moneyText.text = $"{PlayerData.coins}";
    }
}
