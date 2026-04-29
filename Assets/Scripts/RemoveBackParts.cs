using UnityEngine;

public class RemoveBackParts : MonoBehaviour
{
    [SerializeField] GameObject[] _backParts;

    public void Remove()
    {
        foreach(GameObject backPart in _backParts)
        {
            backPart.SetActive(false);
        }
    }
}
