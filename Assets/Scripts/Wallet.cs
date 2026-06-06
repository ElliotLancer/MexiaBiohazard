using UnityEngine;
using TMPro;
public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    public int Coins { get; private set; }
    public void AddCoins (int amount)
    {
        Coins += amount;
    }
    private void Update()
    {
        _moneyText.text = Coins + "";
    }
}
