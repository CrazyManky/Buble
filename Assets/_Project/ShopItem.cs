using _Project._Screpts.Configs;
using Services;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private LevelsConfig _levelsConfig;
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerConfig _playerConfig;
    [SerializeField] private int _maxLevelComplited;
    [SerializeField] private int _itemIndex;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Sprite _spriteActive;
    [SerializeField] private Sprite _spriteInactive;
    [SerializeField] private Button _button;

    private LevelInstance _levelInstance;
    private AudioManager _audioManager;

    private void OnEnable()
    {
        _button.onClick.AddListener(SetItemLevel);
    }

    private void Start()
    {
        _levelInstance = ServiceLocator.Instance.GetService<LevelInstance>();
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        _slider.maxValue = _maxLevelComplited;
        _slider.value = _levelsConfig.CurrentLevel;

        if (_levelsConfig.CurrentLevel >= _maxLevelComplited)
            _itemImage.sprite = _spriteActive;
        else
            _itemImage.sprite = _spriteInactive;
    }


    public void SetItemLevel()
    {
        if (_levelsConfig.CurrentLevel >= _maxLevelComplited)
        {
            _playerConfig.SetPlayer(_itemIndex);
            _levelInstance.ResetLevel();
            _audioManager.PlayButtonClick();
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetItemLevel);
    }
}