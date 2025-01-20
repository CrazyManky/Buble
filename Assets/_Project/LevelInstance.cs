using _Project._Screpts.Configs;
using UnityEngine;

public class LevelInstance : MonoBehaviour, IService
{
    [SerializeField] private LevelsConfig _level;

    private Level _levelInstance;

    private void Start()
    {
        InstanceLevel();
    }


    public void InstanceLevel()
    {
        if (_levelInstance != null)
        {
            Destroy(_levelInstance.gameObject);
        }

        var prefabLevel = _level.GetLevel();
        _levelInstance = Instantiate(prefabLevel);
    }

    public void ResetLevel()
    {
        Destroy(_levelInstance.gameObject);
        _levelInstance = Instantiate(_level.AcitveLevel);
    }
}