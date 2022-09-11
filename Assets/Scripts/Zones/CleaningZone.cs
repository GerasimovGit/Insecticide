using System;
using Hero;
using UnityEngine;

namespace Zones
{
    public class CleaningZone : MonoBehaviour
    {
        public event Action<bool> PlayerEntered;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                PlayerEntered?.Invoke(true);
                player.TrySoot();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                PlayerEntered?.Invoke(false);
                player.StopShoot();
            }
        }
    }
}