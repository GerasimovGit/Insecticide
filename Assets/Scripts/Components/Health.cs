using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;
    
        public void ModifyHealth(int healthDelta)
        {
            if (_health <= 0) return;
            
            _health += healthDelta;

            if (healthDelta < 0) _onDamage?.Invoke();
            
            if (_health <= 0) _onDie?.Invoke();
        }
        
        private void OnDestroy()
        {
            _onDie.RemoveAllListeners();
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {
        }
    }
}