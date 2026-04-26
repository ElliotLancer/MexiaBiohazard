using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;

public class PlayerFlash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _sprites;
    [SerializeField] private float _flashTime = 1f;
    private Color _originalColor;
    private void Start()
    { 
        _originalColor = _sprites[0].color;
    }
    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }
    private IEnumerator FlashRoutine()
    {
        foreach(var sprite in _sprites)
        {
            sprite.color = Color.red;
        }
        yield return new WaitForSeconds(_flashTime);
        foreach (var sprite in _sprites)
        {
            sprite.color = _originalColor;
        }
    }
}
