using _Project._Screpts.Configs;
using Project.Screpts.Screens;
using Services;
using UnityEngine;

public class LevelComplitedScreen : BaseScreen
{
    [SerializeField] private LevelsConfig _levelsConfig;

    private LevelInstance _levelInstance;
    private LevelCounter _levelCounter;

    public override void Init()
    {
        base.Init();
        _levelInstance = ServiceLocator.Instance.GetService<LevelInstance>();
        _levelCounter = ServiceLocator.Instance.GetService<LevelCounter>();
    }

    public void NextLevel()
    {
        AudioManager.PlayButtonClick();
        _levelsConfig.LevelComplited();
        _levelInstance.InstanceLevel();
        _levelCounter.SetLevelIndex();
        Destroy(gameObject);
    }
}