using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project._Screpts.Configs
{
    [Serializable]
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private List<PlayerItems.Player> _playersItems = new();
        [SerializeField] private int _acitvePlayer;
        [SerializeField] private PlayerItems.Player _playerPrefab;

        public PlayerItems.Player GetPlayer()
        {
            return _playersItems[_acitvePlayer];
        }

        public void SetPlayer(int idPlayer)
        {
            _acitvePlayer = idPlayer;
            _playerPrefab = _playersItems[_acitvePlayer];
        }
    }
}