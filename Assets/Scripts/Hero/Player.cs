using System.Collections;
using UnityEngine;
using Weapons;

namespace Hero
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;
        [SerializeField] private CircleOverlap _circleOverlap;
        [SerializeField] private float _shootCooldown;
        [SerializeField] private ParticleSystem[] _shootParticles;

        private float _nextShootAttackTime;
        private WaitForSeconds _waitForSeconds;

        public void TrySoot()
        {
            _waitForSeconds = new WaitForSeconds(_shootCooldown);

            if (_weapon.IsOutOfResource)
            {
                foreach (var particle in _shootParticles)
                {
                    particle.Stop();
                }

                return;
            }

            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            foreach (var particle in _shootParticles)
            {
                particle.Play();
            }
            
            while (_weapon.IsOutOfResource == false)
            {
                _circleOverlap.Check();
                _weapon.Fire();
                yield return _waitForSeconds;
            }
        }

        public void AddResource()
        {
            _weapon.AddResource();
        }
    }
}