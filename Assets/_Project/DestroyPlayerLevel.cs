using _Project._Screpts.PlayerItems;
using UnityEngine;

public class DestroyPlayerLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out var Player))
        {
            Destroy(Player.gameObject);
        }
    }
}