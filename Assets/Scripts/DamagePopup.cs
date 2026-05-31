using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TextMeshPro _popupText;
    [SerializeField] private float _textLifeTime = 1f;
    [SerializeField] private float _moveSpeed = 0.9f;
    private void Start()
    {
        Destroy(gameObject, _textLifeTime);
    }
    private void Update()
    {
        transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
    }
    public void Setup(int damage)
    {
        _popupText.text = $"{damage}";
    }
}
