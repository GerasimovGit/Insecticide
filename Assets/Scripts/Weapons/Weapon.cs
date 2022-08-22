using System;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _resource;
        [SerializeField] private float _resourceLoseSpeed;

        private float _maxResourceValue = 10;

        public event Action ResourceEnded;
        
        public bool IsOutOfResource => _resource <= 0;

        public void Fire()
        {
            _resource -= _resourceLoseSpeed * Time.deltaTime;

            if (IsOutOfResource)
            {
                ResourceEnded?.Invoke();
            }
        }

        public void AddResource()
        {
            _resource = _maxResourceValue;
        }
    }
}