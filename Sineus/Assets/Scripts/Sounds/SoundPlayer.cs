using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private GameSounds m_Sounds;

    private AudioSource _audioSource;
    public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(Sound sound, float pitch)
    {
        _audioSource.pitch = pitch;

        _audioSource.PlayOneShot(m_Sounds[sound]);
    }
}
