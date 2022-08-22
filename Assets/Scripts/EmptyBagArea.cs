using System;
using Hero;
using UnityEngine;

namespace DefaultNamespace
{
    public class EmptyBagArea : MonoBehaviour
    {
        public event Action Triggered;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Player player))
            {
                Triggered?.Invoke();
                player.AddResource();
            }
        }
    }
}