using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _insertCartridgeSound;
    [SerializeField] private AudioClip _pumpSound;
    [SerializeField] private AudioClip _reloadStartSound;
    [SerializeField] private AudioClip _takeMagOutSound;
    [SerializeField] private AudioClip _putMagInSound;
    [SerializeField] private AudioClip _pistolCockSound;
    [SerializeField] private AudioClip _handSwing;
    public void InsertCartridge()
    {
        AudioManager.Instance.Play(_insertCartridgeSound);
    }
    public void PumpReload()
    {
        AudioManager.Instance.Play(_pumpSound);
    }
    public void ShotgunReloadStart()
    {
        AudioManager.Instance.Play(_reloadStartSound);
    }
    public void TakeMagOut()
    {
        AudioManager.Instance.Play(_takeMagOutSound);
    }
    public void PutMagIn()
    {
        AudioManager.Instance.Play(_putMagInSound);
    }
    public void PistolCock()
    {
        AudioManager.Instance.Play(_pistolCockSound);
    }
    public void Swing()
    {
        AudioManager.Instance.Play(_handSwing);
    }
}
