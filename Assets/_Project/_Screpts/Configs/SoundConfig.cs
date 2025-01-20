using UnityEngine;

namespace _Project._Screpts.Configs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] private bool _soundActive;
        
        public bool SoundActive => _soundActive;
        
        
        public void SetData(bool soundActive)
        {
            _soundActive = soundActive;
        }
    }
}