using _Project._Screpts.Player;
using _Project._Screpts.Screens.PrivacyPolicy;
using Project.Screpts.Screens;
using Project.Screpts.Screens.ShopScreen;
using Services;
using UnityEngine;

namespace _Project._Screpts.Screens
{
    public class DialogLauncher : MonoBehaviour, IService
    {
        [SerializeField] private PrivacyPolicyScreen _privacyPolicyScreen;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private SettingsScreen.SettingsScreen _settingsScreen;
        [SerializeField] private LevelComplitedScreen _levelComplited;
        [SerializeField] private InputHandler _inputHandler;
        [SerializeField] private LevelCounter _counter;
        [SerializeField] private LevelInstance _levelInstance;
        [SerializeField] private AudioManager _audioManager;


        private void Awake()
        {
            ServiceLocator.Init();
            ServiceLocator.Instance.AddService(this);
            ServiceLocator.Instance.AddService(_inputHandler);
            ServiceLocator.Instance.AddService(_levelInstance);
            ServiceLocator.Instance.AddService(_counter);
            ServiceLocator.Instance.AddService(_audioManager);
        }

        private void Start()
        {
            ShowPrivacyPolicyScreen();
            _audioManager.PlayGameSound();
        }


        public void ShowPrivacyPolicyScreen()
        {
            ShowScreen(_privacyPolicyScreen);
        }

        public void ShowSettingsScreen()
        {
            _audioManager.PlayButtonClick();
            ShowScreen(_settingsScreen);
        }

        public void ShowShopScreen()
        {
            _audioManager.PlayButtonClick();
            ShowScreen(_shopScreen);
        }

        public void ShowLevelComplitedScreen() => ShowScreen(_levelComplited);

        private void ShowScreen(BaseScreen screen)
        {
            var instanceScreen = Instantiate(screen, transform);
            instanceScreen.Init();
        }
    }
}