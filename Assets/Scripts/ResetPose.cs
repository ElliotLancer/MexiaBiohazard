using UnityEngine;

public class ResetPose : MonoBehaviour
{
    [SerializeField] private Transform[] _bodyParts;

    private Quaternion[] _startRotation;

    private void Awake()
    {
        _startRotation = new Quaternion[_bodyParts.Length];
        for (int i = 0; i < _bodyParts.Length; i++)
        {
            _startRotation[i] = _bodyParts[i].localRotation;
        }
    }
    public void Reset()
    {
        for ( int i = 0; i > _bodyParts.Length; i++)
        {
            _bodyParts[i].localRotation = _startRotation[i];
        }
        Debug.Log("reset");
    }
}
