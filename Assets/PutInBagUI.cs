using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PutInBagUI : MonoBehaviour
{
    [SerializeField] private Image _progressCircle;
    private Transform _target;

    public void Setup(Transform target)
    {
        _target = target;
    }
    public void SetProgress(float amount)
    {
        _progressCircle.fillAmount = amount;
    }
    private void Update()
    {
        if (_target == null)
            return;
        transform.position = _target.position + Vector3.up;
    }
}
