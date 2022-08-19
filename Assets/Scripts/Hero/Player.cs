using UnityEngine;
using Weapons;

namespace Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private CircleOverlap _circleOverlap;
        [SerializeField] private float _shootCooldown;

        private float _nextShootAttackTime;

        private void Update()
        {
            TrySoot();
        }

        public void TrySoot()
        {
            if (_weapon.IsOutOfResource) return;
            
            if (_nextShootAttackTime > Time.time) return;
            _nextShootAttackTime = Time.time + _shootCooldown;

            _circleOverlap.Check();
            _weapon.Fire();
        }
    }
}