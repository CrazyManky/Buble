using _Project._Screpts.Configs;
using UnityEngine;

public class AudioManager : MonoBehaviour,IService
{
    [SerializeField] private SoundConfig _soundConfig;
    [SerializeField] private AudioSource _buttonClickListener;
    [SerializeField] private AudioSource _gameSound;

    public void PlayButtonClick()
    {
        _buttonClickListener.Play();
    }

    public void PlayGameSound()
    {
        _gameSound.Play();
    }

    private void Update()
    {
        if (!_soundConfig.SoundActive)
        {
            _buttonClickListener.volume = 0f;
            _gameSound.volume = 0f;
        }
        else
        {
            _buttonClickListener.volume = 0.1f;
            _gameSound.volume = 0.1f;
        }
    }
}