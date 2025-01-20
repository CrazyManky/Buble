using _Project._Screpts.Configs;
using UnityEngine;

namespace _Project._Screpts.PlayerIntance
{
    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;

        private PlayerItems.Player _player;

        public void InstancePlayer()
        {
            if (_player != null)
            {
                Destroy(_player.gameObject);
            }

            _player = Instantiate(_playerConfig.GetPlayer(), transform);
            _player.transform.position = transform.position;
            _player.Init();
        }

        public void FixedUpdate()
        {
            if (_player == null)
            {
                InstancePlayer();
            }
        }
    }
}