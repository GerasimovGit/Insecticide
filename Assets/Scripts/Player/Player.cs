using UnityEngine;
using Weapons;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private CircleOverlap _circleOverlap;
        [SerializeField] private float _shootCooldown;
        
        private float _nextShootAttackTime;

        private void Update()
        {
            if (_nextShootAttackTime < Time.time)
            {
                _circleOverlap.Check();
                _weapon.Fire();
                _nextShootAttackTime = Time.time + _shootCooldown;
            }
        }
    }
}