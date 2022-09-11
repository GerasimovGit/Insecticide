using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        private const float MAXResourceValue = 10;

        [SerializeField] private float _resource;
        [SerializeField] private float _resourceLoseSpeed;

        public bool IsOutOfResource => _resource <= 0;

        public void Fire()
        {
            if (IsOutOfResource) return;

            _resource -= _resourceLoseSpeed * Time.deltaTime;
        }

        public void AddResource()
        {
            _resource = MAXResourceValue;
        }
    }
}