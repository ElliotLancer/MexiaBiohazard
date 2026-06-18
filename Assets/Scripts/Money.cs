using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private AudioClip _sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Trigger"))
            return;
        Wallet wallet = collision.GetComponent<Wallet>();
        if (wallet != null)
        {
            wallet.AddCoins(_value);
        }
        AudioManager.Instance.Play(_sound);
        Destroy(gameObject);
    }
}
