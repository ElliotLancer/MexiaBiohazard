using UnityEngine;
public class SpawnItems : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _dollar;
    [SerializeField] private GameObject _pistolAmmo;
    [SerializeField] private GameObject _rifleAmmo;
    [SerializeField] private GameObject _shotgunAmmo;

    [SerializeField] private float _secondaryAmmoChance = 0.3f;
    [SerializeField] private int _secondaryAmmoMin = 1;
    [SerializeField] private int _secondaryAmmoMax = 3;

    [SerializeField] private float _primaryAmmoChance = 0.2f;
    [SerializeField] private int _primaryAmmoMin = 1;
    [SerializeField] private int _primaryAmmoMax = 2;

    [SerializeField] private float _coinChance = 0.5f;
    [SerializeField] private float _dollarChance = 0.2f;
    [SerializeField] private int _coinMin = 1;
    [SerializeField] private int _coinMax = 4;

    [SerializeField] private int _dollarMax = 2;
    [SerializeField] private int _dollarMin = 0;

    public void Spawn(Transform pos)
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
        if (Random.value < _secondaryAmmoChance)
        {
            int pistolAmmoAmount = Random.Range(_secondaryAmmoMin, _secondaryAmmoMax);
            for (int i = 0; i < pistolAmmoAmount; i++)
            {
                GameObject pistolAmmo = Instantiate(_pistolAmmo, pos.position, Quaternion.identity);
                Rigidbody2D rb = pistolAmmo.GetComponent<Rigidbody2D>();
                rb.AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
            }
        }
        if (Random.value < _primaryAmmoChance)
        {
            string primaryWeapon = PlayerPrefs.GetString("PrimaryWeapon", "");
            int primaryAmmoAmount = Random.Range(_primaryAmmoMin, _primaryAmmoMax);
            if (primaryWeapon == "rifle")
            {
                for (int i = 0; i < primaryAmmoAmount; i++)
                {
                    GameObject rifleAmmo = Instantiate(_rifleAmmo, pos.position, Quaternion.identity);
                    Rigidbody2D rb = rifleAmmo.GetComponent<Rigidbody2D>();
                    rb.AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
                }
            }
            if (primaryWeapon == "shotgun")
            {
                for (int i = 0; i < primaryAmmoAmount; i++)
                {
                    GameObject shotgunAmmo = Instantiate(_shotgunAmmo, pos.position, Quaternion.identity);
                    Rigidbody2D rb = shotgunAmmo.GetComponent<Rigidbody2D>();
                    rb.AddForce(Random.insideUnitCircle * 1f, ForceMode2D.Impulse);
                }
            }
        }
    }
}
