using _Project._Screpts.PlayerItems;
using _Project._Screpts.Screens;
using Services;
using UnityEngine;

public class LevelComplitedZone : MonoBehaviour
{
    private DialogLauncher _dialogLauncher;

    private void Awake()
    {
        _dialogLauncher = ServiceLocator.Instance.GetService<DialogLauncher>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            _dialogLauncher.ShowLevelComplitedScreen();
            Destroy(player.gameObject);
        }
    }
}