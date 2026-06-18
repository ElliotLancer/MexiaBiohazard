using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _source;

    private void Awake()
    {
        Instance = this;
    }
    public void Play(AudioClip clip)
    {
        _source.PlayOneShot(clip);
    }
}
