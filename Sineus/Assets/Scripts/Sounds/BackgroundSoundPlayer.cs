using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class BackgroundSoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioSource AudioSource { get => _audioSource; set => _audioSource = value; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip bckgroundSound, float volume)
    {
        if (_audioSource.isPlaying)
        {
            _audioSource?.Stop();
        }

        _audioSource.clip = bckgroundSound;

        _audioSource.volume = volume;

        _audioSource.Play();
    }

    public void Stop() 
    {
        if (_audioSource.isPlaying)
            _audioSource.Stop();
    }
}
