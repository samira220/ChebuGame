using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isPlaying = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMusic();
        }
    }

    void ToggleMusic()
    {
        if (_isPlaying)
        {
            _audioSource.Stop();
            _isPlaying = false;
        }
        else
        {
            _audioSource.Play();
            _isPlaying = true;
        }
    }
    public void PauseMusic()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.UnPause();
        }
    }
}


