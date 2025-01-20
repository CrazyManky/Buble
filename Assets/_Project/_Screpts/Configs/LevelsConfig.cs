using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project._Screpts.Configs
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelsConfig")]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<Level> _levels;
        [SerializeField] private int _currentLevel;

        public Level AcitveLevel { get; private set; }
        
        public int CurrentLevel => _currentLevel;

        public Level GetLevel()
        {
            if (_currentLevel >= _levels.Count)
            {
                var randomIndex = Random.Range(0, _levels.Count);
                AcitveLevel = _levels[randomIndex];
                return AcitveLevel;
            }
            
            AcitveLevel = _levels[_currentLevel];
            return AcitveLevel;
        }

        public void LevelComplited()
        {
            _currentLevel++;
        }
    }
}