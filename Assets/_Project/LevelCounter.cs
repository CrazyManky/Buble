using _Project._Screpts.Configs;
using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour, IService
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LevelsConfig _levelsConfig;


    private void Start()
    {
        SetLevelIndex();
    }

    public void SetLevelIndex()
    {
        _text.text = $"Level {_levelsConfig.CurrentLevel + 1}";
    }
}