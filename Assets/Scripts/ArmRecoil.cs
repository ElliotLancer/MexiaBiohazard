using UnityEngine;

public class ArmRecoil : MonoBehaviour
{
    [SerializeField] private Transform armPivot;

    [SerializeField] private float recoilDistance = 0.1f;
    [SerializeField] private float recoilSpeed = 20f;
    [SerializeField] private float returnSpeed = 10f;

    private Vector3 originalPosition;
    private Vector3 currentOffset;
    private void Start()
    {
        originalPosition = armPivot.localPosition;
    }
    private void Update()
    {
        currentOffset = Vector3.Lerp(currentOffset, Vector3.zero, returnSpeed * Time.deltaTime);
        armPivot.localPosition = originalPosition + currentOffset;
    }
    public void Fire()
    {
        currentOffset = Vector3.left * recoilDistance;
    }
}

