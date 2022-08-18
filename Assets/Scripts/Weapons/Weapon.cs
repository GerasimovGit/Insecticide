using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _resource;
        [SerializeField] private float _damage;
        [SerializeField] private float _resourceLoseSpeed;

        public float Damage => _damage;

        public void Fire()
        {
            if (_resource > 0)
            {
                _resource -= _resourceLoseSpeed * Time.deltaTime;
            }
        }
    }
}