using System;
using _Project._Screpts.Configs;
using Project.Screpts.Screens;
using UnityEngine;

namespace _Project._Screpts.Screens.SettingsScreen
{
    public class SettingsScreen : BaseScreen
    {
        [SerializeField] private SoundConfig _soundConfig;
        
        public event Action<bool> OnSoundValueChanged;

        private bool _soundValue;
        public bool SoundValue => _soundValue;

        private void Awake()
        {
            _soundValue = _soundConfig.SoundActive;
        }

        public void SwitchSound()
        {
            AudioManager.PlayButtonClick();
            var soundInverValue = !_soundValue;
            _soundValue = soundInverValue;
            OnSoundValueChanged?.Invoke(soundInverValue);
        }

        public void ShowPrivacyPolicy()
        {
            AudioManager.PlayButtonClick();
            Dialog.ShowPrivacyPolicyScreen();
        }

        public void SetData()
        {
            AudioManager.PlayButtonClick();
            _soundConfig.SetData(_soundValue);
            Destroy(gameObject);
        }

        public void Close()
        {
            AudioManager.PlayButtonClick();
            Destroy(gameObject);
        }
    }
}