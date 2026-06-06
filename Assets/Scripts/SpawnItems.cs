using UnityEngine;
public class SpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _dollar;

    [SerializeField] private float _coinChance = 0.5f;
    [SerializeField] private float _dollarChance = 0.2f;
    [SerializeField] private int _coinMin = 1;
    [SerializeField] private int _coinMax = 4;

    [SerializeField] private int _dollarMax = 2;
    [SerializeField] private int _dollarMin = 0;

    public void SpawnMoney(Transform pos)
    {
        if (Random.value < _coinChance)
        {
            int coinAmount = Random.Range(_coinMin, _coinMax + 1);
            for (int i = 0; i < coinAmount; i++)
            {
                GameObject coin = Instantiate(_coin, pos.position, Quaternion.identity);
                Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
                rb.AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
            }
        }
        if (Random.value < _dollarChance)
        {
            int dollarAmount = Random.Range(_dollarMin, _dollarMax + 1);
            for (int i = 0; i < dollarAmount; i++)
            {
                GameObject dollar = Instantiate(_dollar, pos.position, Quaternion.identity);
                Rigidbody2D rb = dollar.GetComponent<Rigidbody2D>();
                rb.AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
            }
        }
    }
}
