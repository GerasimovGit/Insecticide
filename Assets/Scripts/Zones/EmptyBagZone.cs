using Coins;
using Hero;
using UnityEngine;

namespace Zones
{
    public class EmptyBagZone : MonoBehaviour
    {
        [SerializeField] private Coin _coin;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                player.AddResource();
                _coin.AddCoins(transform.position, 3);
            }
        }
    }
}