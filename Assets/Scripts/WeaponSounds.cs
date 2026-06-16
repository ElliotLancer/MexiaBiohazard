using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _insertCartridgeSound;
    [SerializeField] private AudioClip _pumpSound;
    [SerializeField] private AudioClip _reloadStartSound;
    [SerializeField] private AudioClip _takeMagOutSound;
    [SerializeField] private AudioClip _putMagInSound;

    public void InsertCartridge()
    {
        _audio.PlayOneShot(_insertCartridgeSound);
    }
    public void PumpReload()
    {
        _audio.PlayOneShot(_pumpSound);
    }
    public void ShotgunReloadStart()
    {
        _audio.PlayOneShot(_reloadStartSound);
    }
    public void TakeMagOut()
    {
        _audio.PlayOneShot(_takeMagOutSound);
    }
    public void PutMagIn()
    {
        _audio.PlayOneShot(_putMagInSound);
    }
}
