using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _resource;
        [SerializeField] private float _resourceLoseSpeed;

        public bool IsOutOfResource => _resource < 0;

        public void Fire()
        {
            _resource -= _resourceLoseSpeed * Time.deltaTime;
        }
    }
}