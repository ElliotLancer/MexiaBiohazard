using UnityEngine;

public class ArmSwaper : MonoBehaviour
{
    [SerializeField] private GameObject _aliveArm;
    [SerializeField] private GameObject _aliveBackArm;
    [SerializeField] private GameObject _deadArm;
    [SerializeField] private GameObject _deadBackArm;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _backLeg_1;
    [SerializeField] private GameObject _backLeg_2;
    private void Start()
    {
        SwapToAlive();
    }
    public void SwapToDead()
    {
        _aliveArm.SetActive(false);
        _aliveBackArm.SetActive(false);
        _deadArm.SetActive(true);
        _deadBackArm.SetActive(true);
        _weapon.transform.SetParent(null);
        _weapon.GetComponent<SpriteRenderer>().sortingOrder = 7;
        _backLeg_1.SetActive(false);
        _backLeg_2.SetActive(false);
    }
    public void SwapToAlive()
    {
        _aliveArm.SetActive(true);
        _aliveBackArm.SetActive(true);
        _deadArm.SetActive(false);
        _deadBackArm.SetActive(false);
    }

}
