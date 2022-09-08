using System;
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
        [SerializeField] private ParticleSystem _wind;

        private Coroutine _coroutine;

        private float _nextShootAttackTime;
        private WaitForSeconds _waitForSeconds;

        private void OnEnable()
        {
            _weapon.ResourceEnded += OnResourceEnded;
        }

        private void OnDisable()
        {
            _weapon.ResourceEnded -= OnResourceEnded;
        }

        private void OnResourceEnded()
        {
            foreach (var particle in _shootParticles)
            {
                particle.Stop();
            }
            
            _wind.Play();
        }

        public void TrySoot()
        {
            _waitForSeconds = new WaitForSeconds(_shootCooldown);

            if (_weapon.IsOutOfResource)
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                return;
            }

            _coroutine = StartCoroutine(Shoot());
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
            _wind.Stop();
        }
    }
}